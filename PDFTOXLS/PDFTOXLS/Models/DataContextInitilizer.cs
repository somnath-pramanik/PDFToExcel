using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PDFTOXLS.Models
{
    public class DataContextInitilizer : CreateDatabaseIfNotExists<MainContext>
    {
      
        public static void MyLayOutData()
        {
             MainContext context = new MainContext();
             MyLayout layout1 = new MyLayout
            {
                DateCreated=DateTime.Now,
                ProfileName = "Administrator",
                Description = "Admin Profile",
                IsActive = true
            };
             context.MyLayout.Add(layout1);
             context.SaveChanges();
        }

        public static void Module()
        {
            MainContext context = new MainContext();
            Module module1 = new Module {DateCreated=DateTime.Now, Name = "DEF_TICKET", ECaption = "Define Ticket", LCaption = "Ticket", Rigths = ModuleRights.All };


           context.Module.Add(module1);
            context.SaveChanges();
        }
        public static void ModelSectionTicket(int defaultLayoutId)
        {
            MainContext context = new MainContext();
            ModuleSection moduleSec1 = new ModuleSection
            {
                DateCreated = DateTime.Now,
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),
                Name = "Ticket Information",
                sectioncloumn = SectionColumn.TwoColumn,
                SerialNo = 1,
                IsRemovable = false,
                mylayout = (from _d in context.MyLayout where _d.ID == defaultLayoutId select _d).FirstOrDefault()
            };


            context.ModuleSection.Add(moduleSec1);
            context.SaveChanges();
          
        }
        public static void ModelFieldsTicket(int defaultLayoutId)
        {
            MainContext context = new MainContext();

            var mymodule = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault();

            FieldList modulefiled1 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),
               
                Caption = "Date",
                Name = "DateCreated",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Date,
                Length = 50,
               RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated=DateTime.Now,
                columnWidth=70,
                IsRemovable = false


            };
            context.FieldList1.Add(modulefiled1);
            context.SaveChanges();

            FieldList modulefiled2 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),
               
                Caption = "Category",
                Name = "Category",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Select,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled2);
            context.SaveChanges();
            FieldList modulefiled3 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),
               
                Caption = "Product",
                Name = "Product",
               DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Select,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = true,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled3);
            context.SaveChanges();

            //FieldList modulefiled4 = new FieldList
            //{
            //    modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
            //    module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),
               
            //    Caption = "Customer",
            //    Name = "Client",
            //    DefaultValue = "",
            //    SerialNo = 2,
            //    Type = FieldType_ModuleFields.Select,
            //    Length = 50,
            //    RoundOption = FieldRoundOption.None,
            //    PickList = "",
            //    isFirstDefaultValue = false,
            //    CheckBox = false,
            //    IsExisting = false,
            //    IsMandatory = true,
            //    IsCustom = false,
            //    IsHelpPop = true,
            //    HelpPopUrl = "HelpPopPotentialList",
            //    IsReadonly = true,
            //    SpecialCSSClass = "topinputbox",
            //    DateCreated = DateTime.Now,
            //    //isAdminVisible = true,
            //    //isManagerVisible = true,
            //    //isMemberVisible = true,
            //    //isClientVisible = true,
            //    columnWidth = 70,
            //    IsRemovable = false

            //};
            //context.FieldList1.Add(modulefiled4);
            //context.SaveChanges();

            FieldList modulefiled5 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),
               
                Caption = "Company Initials",
                Name = "CompanyInitials",
                 DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = true,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled5);
            context.SaveChanges();

            FieldList modulefiled6 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),
               
                Caption = "Priority",
                Name = "Priority",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = true,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled6);
            context.SaveChanges();

            FieldList modulefiled7 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),
               
                Caption = "Entry/Report",
                Name = "EntryReport",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = true,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled7);
            context.SaveChanges();

            FieldList modulefiled8 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
               module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),
               
                Caption = "Main Module",
                Name = "Modules",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Select,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = true,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled8);
            context.SaveChanges();

            FieldList modulefiled9 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),
               
                Caption = "Sub Module",
                Name = "SubModule",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = true,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled9);
            context.SaveChanges();

            FieldList modulefiled10 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),
               
                Caption = "Issue Summary",
                Name = "IssueSummary",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = true,
                columnWidth = 150,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled10);
            context.SaveChanges();

            FieldList modulefiled11 = new FieldList
            {
               modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
               module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),
               
                Caption = "Step/Description",
                Name = "StepDescription",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.TextArea,
                Length = 50,
               RoundOption = FieldRoundOption.None,
               PickList = "",
               isFirstDefaultValue = false,
               CheckBox = false,
               IsExisting = false,
               IsMandatory = true,
               IsCustom = false,
               IsHelpPop = true,
               HelpPopUrl = "HelpPopPotentialList",
               IsReadonly = true,
               SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = true,
               columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled11);
            context.SaveChanges();

            FieldList modulefiled12 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),
               
                Caption = "Result",
                Name = "Result",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.TextArea,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = true,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled12);
            context.SaveChanges();

            //FieldList modulefiled13 = new FieldList
            //{
            //    modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
            //    module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),
               
            //    Caption = "Attachment",
            //    Name = "Attachment",
            //    DefaultValue = "",
            //    SerialNo = 2,
            //    Type = FieldType_ModuleFields.File,
            //    Length = 50,
            //    RoundOption = FieldRoundOption.None,
            //    PickList = "",
            //    isFirstDefaultValue = false,
            //    CheckBox = false,
            //    IsExisting = false,
            //    IsMandatory = true,
            //    IsCustom = false,
            //    IsHelpPop = true,
            //    HelpPopUrl = "HelpPopPotentialList",
            //    IsReadonly = true,
            //    SpecialCSSClass = "topinputbox",
            //    DateCreated = DateTime.Now,
            //    //isAdminVisible = true,
            //    //isManagerVisible = true,
            //    //isMemberVisible = true,
            //    //isClientVisible = true,
            //    columnWidth = 70,
            //    IsRemovable = false

            //};
            //context.FieldList1.Add(modulefiled13);
            //context.SaveChanges();

            FieldList modulefiled14 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),
               
                Caption = "Assign To",
                Name = "assigned_to_id",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled14);
            context.SaveChanges();

          
           

            FieldList modulefiled15 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "Auto Genereted ID",
                Name = "Id",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled15);
            context.SaveChanges();

            FieldList modulefiled16 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "Ticket NO",
                Name = "TicketNO",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled16);
            context.SaveChanges();

            FieldList modulefiled17 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "Required Date ",
                Name = "REQ_DATE",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled17);
            context.SaveChanges();


            FieldList modulefiled18 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "APPROVED ",
                Name = "APPROVED",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled18);
            context.SaveChanges();


            FieldList modulefiled19 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "REMARKS",
                Name = "REMARKS",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled19);
            context.SaveChanges();


            FieldList modulefiled20 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "STATUS",
                Name = "STATUS",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled20);
            context.SaveChanges();

            FieldList modulefiled21 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "EXPECTED TIME ",
                Name = "EXPECTED_TIME",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled21);
            context.SaveChanges();


            FieldList modulefiled22 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "START DATE",
                Name = "START_DATE",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled22);
            context.SaveChanges();

            FieldList modulefiled23 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "END DATE",
                Name = "END_DATE",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled23);
            context.SaveChanges();

            FieldList modulefiled24 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "Assignee Remarks",
                Name = "REMARKS_ASSIGNEE",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled24);
            context.SaveChanges();

            FieldList modulefiled25 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "Close Remarks",
                Name = "CloseRemarks",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled25);
            context.SaveChanges();

            FieldList modulefiled26 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "REMARKS REVIEW",
                Name = "REMARKS_REVIEW",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled26);
            context.SaveChanges();

            FieldList modulefiled27 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "GRADE",
                Name = "GRADE",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled27);
            context.SaveChanges();

            FieldList modulefiled28 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "TIME TAKEN",
                Name = "TIME_TAKEN",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled28);
            context.SaveChanges();

            FieldList modulefiled29 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "Average Grade",
                Name = "AVG_GRADE",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled29);
            context.SaveChanges();

            FieldList modulefiled30 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "TIME CONSUMED",
                Name = "TIME_CONSUMED",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled30);
            context.SaveChanges();


            FieldList modulefiled31 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "Client ",
                Name = "CLNT_ID",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled31);
            context.SaveChanges();


            FieldList modulefiled32 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "User Id",
                Name = "UserId",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled32);
            context.SaveChanges();


            //FieldList modulefiled33 = new FieldList
            //{
            //    modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
            //    module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

            //    Caption = "User Name",
            //    Name = "UserName",
            //    DefaultValue = "",
            //    SerialNo = 2,
            //    Type = FieldType_ModuleFields.Text,
            //    Length = 50,
            //    RoundOption = FieldRoundOption.None,
            //    PickList = "",
            //    isFirstDefaultValue = false,
            //    CheckBox = false,
            //    IsExisting = false,
            //    IsMandatory = true,
            //    IsCustom = false,
            //    IsHelpPop = true,
            //    HelpPopUrl = "HelpPopPotentialList",
            //    IsReadonly = true,
            //    SpecialCSSClass = "topinputbox",
            //    DateCreated = DateTime.Now,
            //    //isAdminVisible = true,
            //    //isManagerVisible = true,
            //    //isMemberVisible = true,
            //    //isClientVisible = false,
            //    columnWidth = 70,
            //    IsRemovable = false

            //};
            //context.FieldList1.Add(modulefiled33);
            //context.SaveChanges();


            FieldList modulefiled34 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "Version",
                Name = "Version",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled34);
            context.SaveChanges();


            FieldList modulefiled35 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "Modules",
                Name = "Modules",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled35);
            context.SaveChanges();


            FieldList modulefiled36 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "Attachment Path",
                Name = "AttachmentPath",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled36);
            context.SaveChanges();


            FieldList modulefiled37 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "Is Client",
                Name = "is_clnt",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled37);
            context.SaveChanges();


            FieldList modulefiled38 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "Is Changes",
                Name = "IsChanges",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled38);
            context.SaveChanges();

            FieldList modulefiled39 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "group",
                Name = "group_id",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled39);
            context.SaveChanges();

            FieldList modulefiled40 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "Internal/External",
                Name = "IsInternalOrExternal",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled40);
            context.SaveChanges();

            FieldList modulefiled41 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "Record Mode",
                Name = "RecordMod",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled41);
            context.SaveChanges();

            FieldList modulefiled42 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "Approved Date",
                Name = "ApprovedDate",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled42);
            context.SaveChanges();

            FieldList modulefiled43 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "Assigne  Date ",
                Name = "AssigneDate",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled43);
            context.SaveChanges();

            FieldList modulefiled44 = new FieldList
            {
                modulesection = (from _d in context.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == defaultLayoutId && _d.Name == "Ticket Information" select _d).FirstOrDefault(),
                module = (from _d in context.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault(),

                Caption = "Close Date ",
                Name = "CloseDate",
                DefaultValue = "",
                SerialNo = 2,
                Type = FieldType_ModuleFields.Text,
                Length = 50,
                RoundOption = FieldRoundOption.None,
                PickList = "",
                isFirstDefaultValue = false,
                CheckBox = false,
                IsExisting = false,
                IsMandatory = true,
                IsCustom = false,
                IsHelpPop = true,
                HelpPopUrl = "HelpPopPotentialList",
                IsReadonly = true,
                SpecialCSSClass = "topinputbox",
                DateCreated = DateTime.Now,
                //isAdminVisible = true,
                //isManagerVisible = true,
                //isMemberVisible = true,
                //isClientVisible = false,
                columnWidth = 70,
                IsRemovable = false

            };
            context.FieldList1.Add(modulefiled44);
            context.SaveChanges();
          
          
        }

    }
}