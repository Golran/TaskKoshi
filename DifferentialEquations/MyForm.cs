using System.Drawing;
using System.Windows.Forms;
using DifferentialEquations.Actions;

namespace DifferentialEquations
{
    public class MyForm : Form
    {
        public MyForm(IUiAction[] actions, ChartHolder chartHolder)
        {
            ClientSize = new Size(800, 600);
            var mainMenu = new MenuStrip();
            mainMenu.Items.AddRange(actions.ToMenuItems());
            Controls.Add(mainMenu);
            chartHolder.SetParent(this);
        }
    }
}