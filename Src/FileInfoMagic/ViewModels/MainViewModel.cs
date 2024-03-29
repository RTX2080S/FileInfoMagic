﻿using Alienlab.Practices.Utilities;
using FileInfoMagic.Infrastructure.ViewModels;
using FileInfoMagic.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace FileInfoMagic.ViewModels
{
    public class MainViewModel : CommonViewModel, ISubscriber<FileDroppedEventArgs>,
        ISubscriber<ToolbarCommandEventArgs>, ISubscriber<WindowLoadedEventArgs>
    {
        public MainViewModel()
        {
            TabPages = new ObservableCollection<TabBaseViewModel>();
        }

        private ObservableCollection<TabBaseViewModel> tabPages;

        public ObservableCollection<TabBaseViewModel> TabPages
        {
            get
            {
                return tabPages;
            }
            set
            {
                tabPages = value;
                OnPropertyChanged(nameof(TabPages));
            }
        }

        public TabBaseViewModel CurrentTab =>
            (TabPages.Count > 0 && TabIndex < TabPages.Count) ? TabPages[TabIndex] : null;

        private int tabIndex;

        public int TabIndex
        {
            get
            {
                return tabIndex;
            }
            set
            {
                tabIndex = value;
                OnPropertyChanged(nameof(TabIndex));
            }
        }

        public void AddTab(TabBaseViewModel tab)
        {
            if (tab != null)
                TabPages.Add(tab);
        }

        public void RemoveTab(TabBaseViewModel tab)
        {
            if (tab != null)
                TabPages.Remove(tab);
        }

        protected void SwitchToLastTab()
        {
            TabIndex = TabPages.Count - 1;
        }

        protected FileTabViewModel CreateFileTab()
        {
            var fileTab = FileTabViewModel.Create(this);
            this.AddTab(fileTab);
            return fileTab;
        }

        protected DirectoryTabViewModel CreateDirectoryTab()
        {
            var dirTab = DirectoryTabViewModel.Create(this);
            this.AddTab(dirTab);
            return dirTab;
        }

        protected void TryLoadFileInNewTab(string file)
        {
            if (!string.IsNullOrWhiteSpace(file) && File.Exists(file))
            {
                var fileTab = this.CreateFileTab();
                fileTab.LoadPath(file);
            }
            else if (!string.IsNullOrWhiteSpace(file) && Directory.Exists(file))
            {
                var dirTab = this.CreateDirectoryTab();
                dirTab.LoadPath(file);
            }
        }

        protected void AddDefaultTabs()
        {
            this.AddTab(new FileTabViewModel(this));
            this.AddTab(new DirectoryTabViewModel(this));
        }

        public void OnEventHandler(FileDroppedEventArgs e)
        {
            foreach (var file in e.FileDropList)
                this.TryLoadFileInNewTab(file);
        }

        public void OnEventHandler(ToolbarCommandEventArgs e)
        {
            switch (e.Command)
            {
                case ToolbarCommand.NewFile:
                    CreateFileTab();
                    SwitchToLastTab();
                    break;
                case ToolbarCommand.NewDir:
                    CreateDirectoryTab();
                    SwitchToLastTab();
                    break;
                case ToolbarCommand.Open:
                    CurrentTab?.Browse();
                    break;
                case ToolbarCommand.Save:
                    CurrentTab?.Save();
                    break;
                case ToolbarCommand.SaveAll:
                    foreach (var tab in TabPages)
                        tab?.Save();
                    break;
                default:
                    break;
            }
        }

        public void OnEventHandler(WindowLoadedEventArgs e)
        {
            var startupArgs = Environment.GetCommandLineArgs();
            if (startupArgs.Length > 1)
            {
                for (int i = 1; i < startupArgs.Length; i++)
                    this.TryLoadFileInNewTab(startupArgs[i]);
            }

            if (TabPages.Count == 0)
                this.AddDefaultTabs();

            eventAggregator.PublishEvent(new StatusUpdateEventArgs("Ready"));
        }
    }
}
