﻿using System;
using System.IO;
using System.Linq;
using DotNet.Basics.IO;
using DotNet.Basics.NLog;
using DotNet.Basics.Tasks;

namespace SitecoreInstaller.Host
{
    public class SiPageRenderer : IPreflightCheck
    {
        private readonly DirPath _renderRootDir;
        private readonly string _layout;
        private readonly string _notFoundViewName;

        public SiPageRenderer(DirPath renderRootDir, string layout, string notFoundViewName)
        {
            if (renderRootDir == null) throw new ArgumentNullException(nameof(renderRootDir));
            if (layout == null) throw new ArgumentNullException(nameof(layout));
            if (notFoundViewName == null) throw new ArgumentNullException(nameof(notFoundViewName));
            _renderRootDir = renderRootDir;
            _layout = layout;
            _notFoundViewName = notFoundViewName;
        }

        public string RenderNotFound()
        {
            var layout = Load(_layout);
            var page = Load($"{_notFoundViewName}");
            return Render(layout, page);

        }
        public string Render(string name)
        {
            var layout = Load(_layout);
            var page = LoadView(name);
            return Render(layout, page);
        }

        private string Render(SiPage page, params SiPage[] subPages)
        {
            //render depth first
            subPages = subPages.Select(sp =>
            {
                var modulePages = sp.Modules.Select(LoadView).ToArray();
                var html = Render(sp, modulePages);
                return new SiPage(html);
            }).ToArray();

            var renderedHtml = page.Html;
            foreach (var placeholder in page.Placeholders)
            {
                var replacedContent = string.Empty;

                foreach (var subPage in subPages)
                {
                    if (subPage.Sections.ContainsKey(placeholder))
                        replacedContent += $"{subPage.Sections[placeholder]}\r\n";
                }
                renderedHtml = renderedHtml.Replace($"@@{placeholder}@@", replacedContent);
            }
            return renderedHtml;
        }

        private SiPage LoadView(string name)
        {
            return Load($"views\\{name}");
        }
        private SiPage Load(string name)
        {
            try
            {
                var html = _renderRootDir.ToFile($"{name}.html").ReadAllText();
                return new SiPage(html);
            }
            catch (FileNotFoundException)
            {
                this.NLog().Warn("View not foud:" + name);
                return new SiPage(RenderNotFound());
            }
        }

        public TaskResult Assert()
        {
            return new TaskResult(issues =>
            {
                //assert view dir exists
                try
                {
                    _renderRootDir.Exists(throwIoExceptionIfNotExists: true);
                }
                catch (Exception e)
                {
                    issues.Add(e.ToString());
                }
            });
        }
    }
}
