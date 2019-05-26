﻿using CompositeCommands.Core;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using System;

namespace CompositeCommandExample.ViewModel
{
    public class View2ViewModel : BindableBase //, IActiveAware //comes from prism
    {
        IApplicationCommands _applicationCommands;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _canUpdate = true;
        public bool CanUpdate
        {
            get { return _canUpdate; }
            set { SetProperty(ref _canUpdate, value); }
        }

        private string _updatedText;
        public string UpdateText
        {
            get { return _updatedText; }
            set { SetProperty(ref _updatedText, value); }
        }

        public DelegateCommand UpdateCommand { get; private set; }

        public View2ViewModel(IApplicationCommands applicationCommands)
        {
            _applicationCommands = applicationCommands;

            UpdateCommand = new DelegateCommand(Update).ObservesCanExecute(() => CanUpdate);

            _applicationCommands.SaveAllCommand.RegisterCommand(UpdateCommand);
        }

        private void Update()
        {
            UpdateText = $"Updated: {DateTime.Now}";
        }

        /// <summary>
        /// To be called on Dispose
        /// </summary>
        public void Destroy()
        {
            _applicationCommands.UnregisterCommand(UpdateCommand);
        }

        //bool _isActive;
        //public bool IsActive
        //{
        //    get { return _isActive; }
        //    set
        //    {
        //        _isActive = value;
        //        OnIsActiveChanged();
        //    }
        //}
        //private void OnIsActiveChanged()
        //{
        //    UpdateCommand.IsActive = IsActive;

        //    IsActiveChanged?.Invoke(this, new EventArgs());
        //}

        //public event EventHandler IsActiveChanged;
    }
}