using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace Sistema.ServicioWindows
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller serviceProcessInstaller;
        private ServiceInstaller serviceInstaller;

        public ProjectInstaller()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.serviceProcessInstaller = new ServiceProcessInstaller();
            this.serviceInstaller = new ServiceInstaller();

            // Configurar cuenta de ejecución (LocalSystem para acceso sin login de usuario)
            this.serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
            this.serviceProcessInstaller.Password = null;
            this.serviceProcessInstaller.Username = null;

            // Configurar metadatos del servicio
            this.serviceInstaller.ServiceName = "ZKTecoHospitalElProgresoService";
            this.serviceInstaller.DisplayName = "Servicio de Asistencias ZKTeco - Hospital de El Progreso";
            this.serviceInstaller.Description = "Monitorea y sincroniza en tiempo real los relojes biométricos ZKTeco con PostgreSQL y Redis para el Hospital de El Progreso.";
            this.serviceInstaller.StartType = ServiceStartMode.Automatic;

            this.Installers.AddRange(new Installer[] {
                this.serviceProcessInstaller,
                this.serviceInstaller
            });
        }
    }
}
