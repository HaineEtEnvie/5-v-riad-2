using WpfApp6.Infrastructure.Commands.Base;
using WpfApp6.ViewModels;

namespace WpfApp6.Infrastructure.Commands;

public class ResetCommand : Command
{
    public override bool CanExecute(object parameter)
    {
        return true;
    }

    public override void Execute(object parameter)
    {
        object[] parameters = parameter as object[];
        MainWindowViewModel mwvm = parameters[0] as MainWindowViewModel;
        MainWindow mainWindow = parameters[1] as MainWindow;
        
        ResetGame(mwvm, mainWindow);
    }

    internal void ResetGame(MainWindowViewModel mwwm, MainWindow mainWindow)
    {
        mwwm.ResetF();
        mwwm.Game.Move = "X";
        mainWindow.Control.ItemsSource = mwwm.F;
    }
}