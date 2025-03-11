﻿using System.Reflection;

namespace Demo.Core.Constants
{
    public class MessageCodes
    {




        //public const string PasswordResetReqNotCompleted = "auth.password.reset.not.completed";
        //public const string SystemUserNotFound = "system.user.not.found";
        //public const string DefaultTenantNotFound = "tenant.default.not.found";
        //public const string InvalidResetPasswordRequest = "invalid.reset.password.request";
        //public const string NotDataForUserId = "no.data.for.user";
        //public const string ListCompaniesByTenantUserUnAuthorizedError = "list.companies.by.tenant.user.unauthorized.error";
        //public const string RoleAlreadyHasCompany = "role.already.has.company";
        //public const string LastCompanyInfoAssignedToRoleCannotDelete = "last.company.info.assigned.to.role.not.deleted";
        //public const string InvalidResetPasswordCode = "invalid.reset.password.code";
        // public const string PasswordResetActiveForUser = "auth.password.reset.active";



        public const string InsertRoleUnAuthorizedUserTenantError = "insert.role.companies.user.unauthorized.error";
        public const string InsertRoleUnAuthorizedCompanyTenantError = "insert.role.companies.tenant.unauthorized.error";
        public const string ListTenantRoleButUserCompanyUserUnAuthorizedError = "list.tenant.role.user.company.user.unauthorized.user";



        //TODO msozeri: insert followings to the message table? by running query on db.
        // Added
        public const string UnAuthorizedPermissionEndpoint = "endpoint.permission.unauthorized";
        // Not Added Yet
        public const string TokenIsRequired = "token.is.required";
        public const string BearerIsRequired = "bearer.is.required";
        public const string TokenTimeout = "token.timeout";
        public const string InvalidToken = "invalid.token";
        public const string TokenDoesNotMatch = "token.does.not.match";
        public const string TokenCreationFail = "token.creation.fail";
        public const string NotFound = "data.not.found";
        public const string TenantNotFound = "tenant.not.found";
        public const string CompanyNotFound = "company.not.found";
        public const string UserNotFound = "user.not.found";
        public const string UserSettingNotFound = "user.setting.not.found";
        public const string InsertError = "insert.error";
        public const string UpdateError = "update.error";
        public const string IdIsRequiered = "id.required";
        public const string NameIsRequired = "name.required";
        public const string DeleteError = "delete.error";
        public const string ListCannotBeEmpty = "list.cannot.be.empty";
        public const string ModelCannotBeEmpty = "model.cannot.be.empty";
        public const string UserRoleUnauthorized = "user.role.unauthorized";
        public const string TenantLicenceExpired = "tenant.licence.expired";
        public const string PasswordNotMatchedMinRequired = "password.not.matched.min.length.requirement";
        public const string PasswordNotMatchedStrengthRequired = "password.not.matched.strength.requirement";
        public const string ProfilePasswordNotMatched = "profile.password.not.matched";
        public const string ProfilePasswordNotChanged = "profile.password.not.changed";
        public const string PasswordNewIsRequired = "password.new.is.required";
        public const string PasswordNewAgainIsRequired = "password.new.again.is.required";
        public const string TenantLicenceNotFound = "tenant.licence.not.found";
        public const string FieldNotFound = "field.not.found";
        public const string TCCitizenNotFound = "not.found.tc.citizen";
        public const string CitizenIdIsNotValid = "citizen.id.is.not.valid";
        public const string BirthDateIsRequired = "birth.date.is.required";
        public const string IdentityCardIsRequired = "identity.card.is.required";
        public const string UploadError = "upload.error";
        public const string PersonFormIsRequired = "person.form.is.required";
        public const string CustomerNotFound = "customer.not.found";
        public const string IsJewelryFieldIsRequired = "is.jewelry.field.is.required";
        public const string GroupCodeIsRequired = "group.code.is.required";
        public const string CategoryIdIsRequired = "category.id.is.required";
        public const string ProductGroupIdIsRequired = "product.group.id.is.required";
        public const string GradeIdIsRequired = "grade.id.is.required";
        public const string ColorIdIsRequired = "color.id.is.required";
        public const string ImageIsRequired = "image.is.required";
        public const string SizeIsNotValid = "size.is.not.valid";
        public const string CustomerIdIsRequired = "customer.id.is.required";
        public const string UserNotAllowedIPAddress = "user.not.allowed.ip.address";
        public const string UserNotHavePermissionAnyEndpoint = "endpoint.user.not.have.permission.any";
        public const string MissingRouteValues = "routevalues.missing";
        public const string MissingUserSettings = "user.settings.missing";
        public const string MissingParameter = "parameter.missing";
        public const string TUserSettingsInsertError = "tuser.settings.insert.error";
        public const string TCompanyUserInsertError = "company.tuser.insert.error";
        public const string InsertRoleTenantUnauthorizedError = "insert.role.tenant.unauthorized.error";
        public const string InsertRoleNameInCompanyExistError = "insert.role.name.exist.in.company.error";
        public const string InsertRoleNameInTenantExistError = "insert.role.name.exist.in.tenant.error";
        public const string EMailIsRequired = "email.is.required";
        public const string InvalidEMail = "invalid.email";
        public const string PasswordIsRequired = "password.is.required";
        public const string TenantIdIsRequired = "tenant.id.is.required";
        public const string RoleNameIsRequired = "role.name.is.required";
        public const string RoleIdIsRequired = "role.id.is.required";
        public const string UserIdIsRequired = "user.id.is.required";
        public const string LastNameIsRequired = "lastname.is.required";
        public const string PhoneNumberIsRequired = "phone.number.is.required";
        public const string CompanyIdIsRequired = "company.id.is.required";
        public const string InternalServerError = "internal.server.error";
        public const string UnsupportedMediaTypeError = "unsupported.media.type.error";
        public const string MethodNotAllowedError = "method.not.allowed.error";
        public const string LanguIsRequired = "langu.is.required";
        public const string MenuTypeIsRequired = "menu.type.is.required";
        public const string ColorSchemeIsRequired = "color.scheme.is.required";
        public const string RippleEffectIsRequired = "ripple.effect.is.required";
        public const string LayoutThemeIsRequired = "layout.is.required";
        public const string ComponentThemeIsRequired = "component.theme.is.required";
        public const string NameMustBeUnique = "name.must.be.unique";
        public const string EndDateSmallerThanStartDate = "enddate.smaller.than.startdate";
        public const string StartDateIsRequired = "startdate.required";
        public const string EndDateIsRequired = "enddate.required";
        public const string DescriptionIsRequired = "description.is.required";
        public const string CompanyTUserAlreadyExist = "company.tuser.exist";
        public const string TUserTenantRoleAlreadyExist = "tuser.tenant.role.exist";
        public const string TenantRoleNotFound = "tenant.role.not.found";
        public const string CodeRequired = "code.is.required";
        public const string ActionsCannotBeEmpty = "actions.cannot.be.empty";
        public const string FERouteRequired = "fe.route.is.required";
        public const string ModuleIdRequired = "module.id.is.required";
        public const string UserRoleNotFound = "user.role.not.found";
        public const string ScreenNameorCodeIsExist = "screen.code.name.existing";
        public const string ScreenIdIsRequired = "screen.id.is.required";
        public const string EndpointIsRequired = "endpoint.is.required";
        public const string ScreenActionInsertError = "screenaction.insert.error";
        public const string ScreenActionDeleteError = "screenaction.delete.error";
        public const string ScreenActionExistEndpointInfo = "screenaction.exist.endpoint.info";
        public const string TenantorCompanyorSystemIsRequired = "tenant.or.company.or.system.is.required";
        public const string TUserCompanyRoleAlreadyExist = "tuser.company.role.exist";
        public const string CompanyRoleNotFound = "company.role.not.found";
        public const string ActiveCompanyIsRequired = "active.company.is.required";
        public const string ActiveCompanyInformationIsIncorrect = "active.company.information.is.incorrect";
        public const string DeleteErrorCausedRelation = "delete.error.caused.relation";
        public const string ModuleNotFound = "module.not.found";
        public const string ScreenNotFound = "screen.not.found";
        public const string ScreenCodeIsRequired = "screen.code.is.required";
        public const string ScreenEndpointNotFound = "screen.endpoint.not.found";
        public const string ProcessedDataNotFound = "processed.data.not.found";
        public const string VerifyKeyIsRequired = "verify.key.is.required";
        public const string UnableVerifyCaptcha = "unable.to.verify";
        public const string InvalidCaptchaVerification = "invalid.captcha.verification";
        public const string ItMightBeBoat = "it.might.be.boat";
        public const string TokenTypeIsRequired = "token.type.is.required";
        public const string UserTypeIsRequired = "user.type.is.required";
        public const string RoleActionIsRequired = "role.action.is.required";
        public const string SelectedCompanyOfTenantMustBeSameLoggedTenantOfUser = "selected.company.of.tenant.must.be.same.logged.tenant";
        public const string InCompetentToAddRole = "incompetent.to.add.role";
        public const string Is2FarequiredIsRequired = "is.two.factor.authentication.is.required";
        public const string CaptchaFieldIsRequired = "is.captcha.field.is.required";
        public const string PasswordFieldIsRequired = "is.password.field.is.required";
        public const string SelectedCompanyIsNotInCompanyOfCompanyUser = "selected.company.is.not.in.company.of.company.user";
        public const string TypeIsRequired = "type.is.required";
        public const string TenantAndCompanyAreRequired = "tenant.and.company.are.required";
        public const string RoleNameIsExist = "role.name.existing";
        public const string RoleIsNotUpdateable = "role.is.not.updateable";
        public const string RoleDefinedAsPredefinedCannotBeDeleted = "predefined.role.can.not.be.deleted";
        public const string ListCompanyUserNotTenantUserUnAuthorizedAccessError = "list.company.user.can.not.list.tenant.user.unauthorized.access.error";
        public const string InsertRoleCompaniesNotExistUnauthorizedError = "insert.role.companies.not.exist.unauthorized.error";
        public const string ListTenantRoleButUserTenantNoCompanyAuthorizedError = "list.tenant.role.user.tenant.not.have.any.company.unauthorized.user";
        public const string AuthorizedCompanyAccessError = "unauthorized.company.access.error";
        public const string AuthorizedUserAccessError = "unauthorized.user.access.error";
        public const string NoCompanyError = "there.is.no.company.error";
        public const string UnAuthorizedLicenceEndpoint = "endpoint.licence.unauthorized";
        public const string UnAuthorizedScreen = "endpoint.screen.unauthorized";
        public const string ListTenantUnAuthorizedAccessError = "tenant.unauthorized.access.error";
        public const string ListCompanyRoleUnAuthorizedError = "list.company.role.unauthorized";
        public const string NotFoundRepairRegister = "not.found.repair.register";
        public const string CustomerIsAlreadyExist = "customer.is.already.exist";
        public const string AtLeastOneImageRequired = "at.least.one.image.required";
        public const string DefaultRecordAlreadyExist = "default.record.already.exist";
        public const string DeliveryCodeIsRequired = "delivery.code.is.required";
        public const string MrfIdIsRequired = "mrf.id.is.required";
        public const string ArentSameDeliveryCodes = "delivery.codes.arent.same";
        public const string SendingSmsError = "sending.sms.error";
        public const string DispatchIdIsRequired = "dispatch.id.is.required";


        public const string GrammajIsRequired = "grammage.is.required";
        public const string DispatchMethodIsRequired = "dispatch.method.is.required";
        public const string DispatchTypeIsRequired = "dispatch.type.is.required";
        public const string DispatchLocationIsRequired = "dispatch.location.is.required";
        public const string ProductStatusIsRequired = "product.status.is.required";
        public const string WorkShopAndCenterCannotBeTrueAtSameTime = "workshop.and.center.cannot.be.true.at.same.time";
        public const string ExpiryDateIsRequired = "expiry.date.is.required";
        public const string KvkkTextIsRequired = "kvkk.text.is.required";
        public const string InvalidFileForPdf = "file.is.invalid.for.pdf";
        public const string AcceptanceIsRequiredBeforeShipping = "acceptance.is.required.before.shipping";

        public const string CannotDoOperationOnShippedData = "cannot.do.operation.on.shipped.data";
        public const string AlreadyAccepted = "already.accepted";
        public const string CannotShipToOwnCompany = "cannot.ship.to.own.company";
        public const string CannotAcceptExceptOwnCompany = "cannot.accept.expect.own.company";
        public const string NotFoundDataByScannedQrCode = "not.found.data.by.scanned.qr.code";
        public const string FirstOperationIsMustBeShipping = "first.operation.is.must.be.shipping";
        public const string MethodCannotBeProducerWhenAccept = "method.cannot.be.producer.when.accept";
        public const string CannotDoOperationOnProductShippedToAnotherCompany = "cannot.do.operation.on.product.shipped.to.another.company";
        public const string ProductIsFinished = "product.is.finished";
        public const string ErrorWhileSendingPermitRequestForm = "error.while.sending.permit.request.form";
        public const string ErrorWhileSetPermittedCustomer = "error.while.set.permitted.customer";
        public const string ArentSameOtpCodes = "otp.codes.arent.same";
        public const string ExpressConsentTextIsRequired = "express.consent.text.is.required";
        public const string BarcodesAreRequired = "barcodes.are.required";


    }
}
