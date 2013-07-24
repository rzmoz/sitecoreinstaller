param($installPath, $toolsPath, $package, $project)

# This is the MSBuild targets file to add
$targetsFile = [System.IO.Path]::Combine($toolsPath, 'ConfigTransform.targets')
    
# Need to load MSBuild assembly if it's not loaded yet.
Add-Type -AssemblyName 'Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
# Grab the loaded MSBuild project for the project
$msbuild = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName) | Select-Object -First 1
 
# Make the path to the targets file relative.
$projectUri = new-object Uri('file://' + $project.FullName)
$targetUri = new-object Uri('file://' + $targetsFile)
$toolsUri = new-object Uri('file://' + $toolsPath)

$relativeTargetPath = $projectUri.MakeRelativeUri($targetUri).ToString().Replace([System.IO.Path]::AltDirectorySeparatorChar, [System.IO.Path]::DirectorySeparatorChar)
$relativeToolsPath = $projectUri.MakeRelativeUri($toolsUri).ToString().Replace([System.IO.Path]::AltDirectorySeparatorChar, [System.IO.Path]::DirectorySeparatorChar)

# Add the import and save the project
$msbuild.Xml.AddImport($relativeTargetPath) | out-null

$target = $msbuild.Xml.AddTarget("AfterBuildTransformConfig")
$target.AfterTargets = "AfterBuild"
$task = $target.AddTask("TransformConfig")
$task.SetParameter("ProjectDir", "`$(ProjectDir)")
$task.SetParameter("WorkDir", "$relativeToolsPath")
$task.SetParameter("ConfigTransformDeltaList", "@(ConfigTransformDelta)")
$task.SetParameter("Configuration", "`$(Configuration)")

#$task = $target.AddTask("CopyConfigFilesToTargetDir")
#$task.SetParameter("ConfigTransformDeltaList", "@(ConfigTransformDelta)")
#$task.SetParameter("TargetDir", "`$(TargetDir)")


$project.Save() #persists the changes