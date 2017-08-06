using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Data.Entity;
using PDFTOXLS.Models;



namespace PDFTOXLS.Controllers
{
  

    public class DBController : Controller
    {
       
        public void Initpage()
        {
           
        }
        public void index()
        {
           
          
        }
        // for leed list with pagination block

        // for grid with pagination
        public void ConfirmInstall()
        {
            
        }
        public void Define()
        {
            //Initpage();

            //string conString = System.Configuration.ConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
           
            //var csb = new SqlConnectionStringBuilder(conString);

          
          /// PropertyBag["DataSource"] = csb.DataSource;
         //  PropertyBag["InitialCatalog"] = csb.InitialCatalog;
           

          //  PropertyBag["HeaderCond"] = "Yes";

            //--------------------------------------------logo control
            //DetachedCriteria query_logo = DetachedCriteria.For(typeof(Logo));
            //query_logo.Add(Restrictions.Eq("status", true));
            //var logo = Logo.FindOne(query_logo);
            //PropertyBag["Logo"] = logo.ImgPath;
            //PropertyBag["StylePath"] = logo.StylePath;
            //--------------------------------------------- end logo control

        }

        public static void CreateFieldOfEmployeeForTemplate(string emailid)
        {
           // Logo.SetuplogoData(emailid);
        }
        public static void CreateFieldOfEmployee(Int32 profileid)
        {
            //  ------------------------------------------------------------ create a form field of approved user
           
            //--------------------------------------------------------------  end employee field data here

        }
        //public static bool deleteField(int id)
        //{
        //    var curruser = User.FindOne(Restrictions.Eq("Id", id));
        //    var  modsel = ModuleSection.FindAll(Restrictions.Eq("user", curruser));
        //    var modfld = ModuleFields.FindAll(Restrictions.Eq("user", curruser));
        //    foreach (var extdoc in modsel)
        //    {
        //                extdoc.Delete();
        //    }
        //    foreach (var extdoc in modfld)
        //    {
        //        extdoc.Delete();
        //    }
        //    return true;
        //}

        //----------------------------------------------------------  here database install here ......
        public void installedCRM(int uid)
        {
           // DataContextInitilizer.MyLayOutData();
           // DataContextInitilizer.Module();
          // DataContextInitilizer.ModelSectionTicket(4);
          //  DataContextInitilizer.ModelFieldsTicket(4);
            //PropertyBag["id"] = uid;
            //switch (uid)
            //{
            //    case 1:
            //        GenerateBaseData();
            //        SetupMasterData();
            //        ImportCsv();
            //        break;
            //    case 2:
            //          SectionGRP.SetupSectionGRPData();
                    
            //        Designation.SetupDesignationData(1);
            //        CreateTestUsers();
                
            //        break;
            //    case 3:
            //        Module.SetupModuleData();
                    
            //        break;
            //    case 4:
            //        ModuleSection.SetupModuleSectionData(1);
            //        break;
            //    case 5:
            //        ModuleFields.SetupModuleFieldData(1);
            //        break;
            //    case 6:
            //        ModuleFields.SetupEmployeeFieldData(1);
            //        break;
            //    case 7:
            //        ModuleFields.SetupLocationFieldData(1);
            //        break;
            //    case 8:
            //        ModuleFields.SetupGroupFieldData(1);
            //        break;
            //    case 9:
            //        ModuleFields.SetupBPartnerFieldData(1);
            //        break;
            //    case 10:
            //        ModuleFields.SetupAccountFieldData(1);
            //        break;
            //    case 11:
            //        ModuleFields.SetupNetworkFieldData(1);
            //        //----------------------------------------new add
            //        ModuleFields.SetupPotentialFieldData(1);
            //        ModuleFields.SetupCasesFieldData(1);
            //        ModuleFields.SetupVendorFieldData(1);
            //        ModuleFields.SetupSalesOrderFieldData(1);
            //        ModuleFields.SetupSolutionFieldData(1);
            //        ModuleFields.SetupQuoteFieldData(1);
            //        ModuleFields.SetupMBOFieldData(1);
            //        ModuleFields.SetupPriceBookFieldData(1);
            //        ModuleFields.SetupProductFieldData(1);

            //        ModuleFields.SetupContactFieldData(1);
            //        ModuleFields.SetupCampaignFieldData(1);
            //        Menudb.SetupMasterMenudbData(1);
            //        Menudb.SetupChieldMenudbData(1);

            //        SectionGRPDetails.SetupSectionGRPDetailsData();
            //        //RoleManagement.SetupRoleManagementData(1);
                   
            //        //autonumbering.SetupAutonumberData(1);
            //        Dashboard.SetupDashboardData(1);

            //        ReportFolder.SetupReportFolderData(1);
            //        ReportHeader.SetupReportHeaderData(1);
            //        ReportDetails.SetupReportDetailsData(1);
            //        MboPercentage.SetupMboPercentageData();
            //         ModuleFields.SetupCompanyStructureFieldData(1);
            //        ModuleFields.SetupFeesScheduleFieldData(1);
            //        ModuleFields.SetupCustomerComplainFieldData(1);
            //        break;
            //    case 12:
            //        SubMsg.SetupSubMsgData();
            //        Title.SetupTitleData();
            //        CampaignStatus.SetupStatusData();
            //        CampaignType.SetupCampaignTypeData();
            //        SetuplogoData();
            //        break;
            //    case 13:
            //        CampaignMemberStatus.SetupCampaignMemberStatusData();
            //        InvoiceStatus.SetupInvoiceStatusData();
            //        UsageUnit.SetupUsageUnitData();
            //        ProductCategory.SetupProductCategoryData();
            //        Manyfacturer.SetupManyfacturerData();
            //        //PotentialStage.SetupPotentialStageData();
            //        PotentialType.SetupPotentialTypeData();
            //        PotentialStage.SetupPotentialStageData();
            //        CaseType.SetupCaseTypeData();
            //        CaseOrigin.SetupCaseOriginData();
            //        CaseStatus.SetupCaseStatusData();
            //        CaseReason.SetupCaseReasonData();
            //        QuoteStage.SetupQuoteStageData();
            //        SOCarrier.SetupSOCarrierData();
            //        pricingModel.SetuppricingModelData();
            //        SolutionStatus.SetupSolutionStatusData();
            //        SOStatus.SetupSOStatusData();
            //        VendorGL.SetupVendorGLData();
            //        LeadStatus.SetupLeadStatusData();
            //        RepeatType.SetupRepeatTypeData();
            //        break;
            //    case 14:
            //        LeadSource.SetupLeadSourceData();
            //        ContactRole.SetupContactRoleData();
            //        break;
            //    case 15:
            //        Industry.SetupIndustryData();
            //        break;
            //    case 16:
            //        Rating.SetupRatingData();
            //        break;
            //    case 17:
            //        Priority.SetupPriorityData();
            //        break;
            //    case 18:
            //        AccountType.SetupAccountTypeData();
            //        break;
            //    case 19:
            //        TaskType.SetupTaskTypeData();
            //        break;
            //    case 20:
            //        Status.SetupStatusData();
            //        break;
            //    case 21:
            //          CallPurpose.SetupCallPurposeData();
            //        MailConfig.SetupEmailConfigData();
            //        break;
            //    case 22:
            //        Hours.SetupHoursData();
            //        break;
            //    case 23:
            //        Minutes.SetupMinutesData();
            //        break;
            //    case 24:
            //        AmPm.SetupAmPmData();
            //        break;
            //    case 25:
            //        EmpType.SetupEmpTypeData();
            //        break;
            //    case 26:
            //       // Role.SetupRoleData();
            //        break;
            //    case 27:
            //        OwnerShip.SetupOwnerShipData();
                  
            //        break;
            //    case 28:
            //        // GenerateBaseData();
            //        break;
            //    case 29:
            //        // GenerateBaseData();
            //        break;
            //    case 30:
            //        // GenerateBaseData();
            //        break;

            //}
            //CancelLayout();
            //RenderView("success");

        }
       
    }

}
