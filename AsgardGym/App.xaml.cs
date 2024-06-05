using AsgardGym.Windows;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data;
using System.Windows;

namespace AsgardGym
{
    
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (var context = new GymContext())
            {
                context.Database.EnsureCreated();
            }


        }
    }
}
