//-----------------------------------------------------------------------
// <copyright file="GenericCommand.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary> Defines the generic Command for the button interaction.</summary>
//-----------------------------------------------------------------------
namespace Editor_ViewModel.Logic
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Represents a generic command for the button interaction.
    /// </summary>
    public class GenericCommand : ICommand
    {
        /// <summary>
        /// Represents the action of the current pressed button.
        /// </summary>
        private Action<object> action;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericCommand"/> class.
        /// </summary>
        /// <param name="action">The action to be executed when the <see cref="ICommand"/> is triggered.</param>
        public GenericCommand(Action<object> action)
        {
            this.action = action;
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">The data used by the command, which will never be used.</param>
        /// <returns>Returns always true.</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Represents the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">The data used by the command, which will never be used.</param>
        public void Execute(object parameter)
        {
            action(parameter);
        }

        /// <summary>
        /// Fires the <see cref="this.CanExecuteChanged"/> event.
        /// </summary>
        public void FireCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
