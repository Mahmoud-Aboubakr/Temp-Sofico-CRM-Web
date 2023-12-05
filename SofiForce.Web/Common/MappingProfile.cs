using AutoMapper;
using Models;
using SofiForce.BusinessObjects;

namespace SofiForce.Web.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<BOBranch, BranchModel>();
            CreateMap<BOSupervisor, SupervisorModel>();
            CreateMap<BOApplication, ApplicationModel>();
            CreateMap<BOApplicationFeature, ApplicationFeatureModel>();
            CreateMap<BOApplicationFeaturePermission, ApplicationFeaturePermissionModel>();
            CreateMap<BOApplicationSetting, ApplicationSettingModel>();
            CreateMap<BOAppRole, AppRoleModel>();
            CreateMap<BOAppRoleFeature, AppRoleFeatureModel>();
            CreateMap<BOAppRoleFeaturePermission, AppRoleFeaturePermissionModel>();
            CreateMap<BOAppUser, AppUserModel>();
            CreateMap<BOAppUserBranch, AppUserBranchModel>();
            CreateMap<BOAppUserLocation, AppUserLocationModel>();
            CreateMap<BOAppUserNotification, AppUserNotificationModel>();
            CreateMap<BOAppUserStore, AppUserStoreModel>();
            CreateMap<BOBranch, BranchModel>();
            CreateMap<BOCar, CarModel>();
            CreateMap<BOCarType, CarTypeModel>();
            CreateMap<BOCity, CityModel>();
            CreateMap<BOClient, ClientModel>();
            CreateMap<BOClientAccount, ClientAccountModel>();
            CreateMap<BOClientClassification, ClientClassificationModel>();
            CreateMap<BOClientGroup, ClientGroupModel>();
            CreateMap<BOClientGroupSub, ClientGroupSubModel>();
            CreateMap<BOClientType, ClientTypeModel>();
            CreateMap<BOGovernerate, GovernerateModel>();
            CreateMap<BOItem, ItemModel>();
            CreateMap<BOItemStore, ItemStoreModel>();
            CreateMap<BOItemGroup, ItemGroupModel>();
            CreateMap<BOManufacturer, ManufacturerModel>();
            CreateMap<BOPaymentTerm, PaymentTermModel>();
            CreateMap<BOPriority, PriorityModel>();
            CreateMap<BOReasonType, ReasonTypeModel>();
            CreateMap<BORegion, RegionModel>();
            CreateMap<BORepresentative, RepresentativeModel>();
            CreateMap<BORepresentativeJourney, RepresentativeJourneyModel>();
            CreateMap<BORepresentativeKind, RepresentativeKindModel>();
            CreateMap<BOSalesOrder, SalesOrderModelWeb>();
            CreateMap<BOSalesOrderDetail, SalesOrderDetailModel>();
            CreateMap<BOSalesOrderError, SalesOrderErrorModel>();
            CreateMap<BOSalesOrderLog, SalesOrderLogModel>();
            CreateMap<BOSalesOrderSource, SalesOrderSourceModel>();
            CreateMap<BOSalesOrderStatus, SalesOrderStatusModel>();
            CreateMap<BOSalesOrderType, SalesOrderTypeModel>();
            CreateMap<BOStore, StoreModel>();
            CreateMap<BOStoreType, StoreTypeModel>();
            CreateMap<BOSupervisor, SupervisorModel>();
            CreateMap<BOSupervisorType, SupervisorTypeModel>();
            CreateMap<BOVendor, VendorModel>();
            CreateMap<BOVendorGroup, VendorGroupModel>();
            CreateMap<BOClientPlan, ClientPlanModel>();
            CreateMap<BOOperationRequest, OperationRequestModel>();
            CreateMap<BOOperationRequestDetail, OperationRequestDetailModel>();
            CreateMap<BOOperationRequestDetailDocument, OperationRequestDetailDocumentModel>();
            CreateMap<BOOperationRequestDetailLandmark, OperationRequestDetailLandmarkModel>();
            CreateMap<BOOperationRequestDetailPreferredTime, OperationRequestDetailPreferredTimeModel>();
            CreateMap<BOClientComplain, ClientComplainModel>();
            CreateMap<BOComplainType, ComplainTypeModel>();
            CreateMap<BOComplainStatus, ComplainStatusModel>();
            CreateMap<BOComplainTypeDetail, BOComplainTypeDetail>();
            CreateMap<BODepartment, DepartmentModel>();
            CreateMap<BOPriority, PriorityModel>();

            CreateMap<BOClientServiceRequest, ClientServiceRequestModel>();
            CreateMap<BOClientServiceRequestDocument, ClientServiceRequestDocumentModel>();
            CreateMap<BOClientServiceRequestTimline, ClientServiceRequestTimlineModel>();
            CreateMap<BORequestStatus, RequestStatusModel>();
            CreateMap<BORequestType, RequestTypeModel>();
            CreateMap<BORequestTypeDetail, RequestTypeDetailModel>();

            CreateMap<BOClientSurveyDetail, ClientSurveyDetailModel>();
            CreateMap<BOClientSurvey, ClientSurveyModel>();
            CreateMap<BOServeyGroup, ServeyGroupModel>();
            CreateMap<BOServeyStatus, ServeyStatusModel>();
            CreateMap<BOSurveyDetail, SurveyDetailAnswerModel>();
            CreateMap<BOSurveyDetail, SurveyDetailModel>();
            CreateMap<BOSurvey, SurveyModel>();

            CreateMap<BOClientActivity, ClientActivityModel>();


            CreateMap<BOPromotionCriteriaAttrCustom, PromotionCriteriaAttrCustomModel > ();
            CreateMap <BOPromotionCriteriaAttr, PromotionCriteriaAttrModel > ();
            CreateMap <BOPromotionCriteria, PromotionCriteriaModel > ();
            CreateMap <BOPromotionGroup, PromotionGroupModel > ();
            CreateMap <BOPromotionInput, PromotionInputModel > ();
            CreateMap <BOPromotionMixGroup, PromotionMixGroupModel > ();
            CreateMap <BOPromotion, PromotionModel > ();
            CreateMap <BOPromotionOrderHistory, PromotionOrderHistoryModel > ();
            CreateMap <BOPromotionOutcome, PromotionOutcomeModel > ();
            CreateMap <BOPromotionOutput, PromotionOutputModel > ();
            CreateMap <BOPromotionType, PromotionTypeModel > ();

            CreateMap <BOPromtionCriteriaClientAttrCustom, PromtionCriteriaClientAttrCustomModel > ();
            CreateMap <BOPromtionCriteriaClientAttr, PromtionCriteriaClientAttrModel > ();
            CreateMap <BOPromtionCriteriaClient, PromtionCriteriaClientModel > ();

            CreateMap<BOPromtionCriteriaSalesManAttrCustom, PromtionCriteriaSalesManAttrCustomModel>();
            CreateMap<BOPromtionCriteriaSalesManAttr, PromtionCriteriaSalesManAttrModel>();
            CreateMap<BOPromtionCriteriaSalesMan, PromtionCriteriaSalesManModel>();

            CreateMap<BOBranchInvoiceingOrder, BranchInvoiceingOrderModel>();
            CreateMap<BOBranchInvoiceingSetup, BranchInvoiceingSetupModel>();
            CreateMap<BOBusinessUnit, BusinessUnitModel>();
            CreateMap<BOClientRoute, ClientRouteModel>();
            CreateMap<BORouteSetup, RouteSetupModel>();

            CreateMap<BOSupervisorComission, SupervisorComissionModel>();
            CreateMap<BORepresentativeComission, RepresentativeComissionModel>();

            CreateMap<BOSalesOrderAddress, SalesOrderAddressModel>();

        }
    }
}
