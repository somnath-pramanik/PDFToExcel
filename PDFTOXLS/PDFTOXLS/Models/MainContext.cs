using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
using System.Web.Configuration;
using System.Data;
using System;
using System.Linq;
namespace PDFTOXLS.Models
{
    public class MainContext : DbContext
    {
        public MainContext()
            : base("name=MainContext")
        {
        }

        // public DbSet<Ex_user> Ex_user { get; set; }
        public DbSet<Ex_user_new> Ex_user_new { get; set; }
        //public DbSet<Group> Group { get; set; }
        // public DbSet<Ticket> Ticket { get; set; }
       

       // public DbSet<RoleMaster> RoleMaster { get; set; }
       // public DbSet<Client> Client { get; set; }
        //public DbSet<Client_Group> Client_Group { get; set; }

     //   public DbSet<ProductModule> ProductModule { get; set; }


        //public DbSet<User_Client> User_Client { get; set; }

       // public DbSet<Module> Module { get; set; }
      

        //public DbSet<notifications> notifications { get; set; }
        //public DbSet<notification_recipients> notification_recipients { get; set; }
       
       // public DbSet<Product> Product { get; set; }
        public DbSet<PdfConvertRecord> PdfConvertRecord { get; set; }
      

       
        public DbSet<tbTimeZoneInfo> tbTimeZoneInfo { get; set; }
     
        public DbSet<USERLOG> USERLOG { get; set; }
      
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            var changeSet = ChangeTracker.Entries();
            if (changeSet != null)
            {
                foreach (var _x in changeSet)
                {
                    if (_x.State.ToString().ToUpper() == "ADDED" || _x.State.ToString().ToUpper() == "MODIFIED")
                    {
                        DateTime _date = new DateTime(1900, 1, 1);
                        foreach (PropertyInfo propertyInfo in _x.Entity.GetType().GetProperties())
                        {
                            var propertyType = propertyInfo.PropertyType;
                            if (propertyType.IsGenericType &&
                                propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                            {
                                propertyType = propertyType.GetGenericArguments()[0];
                            }


                            if (propertyType.Name == "DateTime")
                            {

                                if (_x.State.ToString().ToUpper() == "ADDED")
                                {
                                    if (propertyInfo.GetValue(_x.Entity, null) != null)
                                    {
                                        _date = (DateTime)propertyInfo.GetValue(_x.Entity, null);
                                        if (_date != null && _date.Year >= 1900)
                                        {
                                            _date = _date.ToUniversalTime();
                                            
                                            propertyInfo.SetValue(_x.Entity, _date);
                                        }
                                    }
                                }
                                else
                                {

                                    var curr_value = (from yy in _x.CurrentValues.PropertyNames.ToDictionary(pn => pn, pn => _x.CurrentValues[pn]) where yy.Key == propertyInfo.Name select yy.Value).SingleOrDefault();
                                    var ORG_value = (from yy in _x.OriginalValues.PropertyNames.ToDictionary(pn => pn, pn => _x.OriginalValues[pn]) where yy.Key == propertyInfo.Name select yy.Value).SingleOrDefault();
                                    if ((ORG_value != null && curr_value != null) && !ORG_value.Equals(curr_value))
                                    {

                                        _date = (DateTime)propertyInfo.GetValue(_x.Entity, null);
                                        if (_date != null && _date.Year >= 1900)
                                        {
                                            _date = _date.ToUniversalTime();
                                            propertyInfo.SetValue(_x.Entity, _date);
                                        }

                                    }


                                }

                            }
                        }
                    }
                }
            }
            return base.SaveChanges();
        }

        private static Type GetCoreType(Type type)
        {
            if (type.IsGenericType &&
                type.GetGenericTypeDefinition() == typeof(Nullable<>))
                return Nullable.GetUnderlyingType(type);
            else
                return type;
        }
    }
}