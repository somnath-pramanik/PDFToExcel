using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Web.Configuration;


namespace PDFTOXLS.Models
{
    public class CompanyContext : DbContext
    {
        //SqlConnectionStringBuilder conn2 = new SqlConnectionStringBuilder(WebConfigurationManager.ConnectionStrings["CompanyContext"].ToString()) { InitialCatalog = new SqlConnectionStringBuilder(WebConfigurationManager.ConnectionStrings["MainContext"].ToString()).InitialCatalog + Session["Company"].ToString();] }; 

        public CompanyContext()
            : base("name=CompanyContext")
        {
        }

        public CompanyContext(string connString)
            : base("name=CompanyContext")
        {
            this.Database.Connection.ConnectionString = connString;
        }
        
        //public DbSet<Ex_user> Ex_user { get; set; }
        //public DbSet<Ticket> Ticket { get; set; }
        //public DbSet<TASK_DETAIL> TASK_DETAIL { get; set; }

        //public DbSet<Client> Client { get; set; }
        //public DbSet<Client_Group> Client_Group { get; set; }

        //public DbSet<Module> Module { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        
        
    }
}