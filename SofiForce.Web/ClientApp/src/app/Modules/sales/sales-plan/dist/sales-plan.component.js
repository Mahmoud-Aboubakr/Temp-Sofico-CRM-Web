"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
exports.__esModule = true;
exports.SalesPlanComponent = void 0;
var core_1 = require("@angular/core");
var en_1 = require("./i18n/en");
var ar_1 = require("./i18n/ar");
var chooser_client_component_1 = require("../../shared/chooser-client/chooser-client.component");
var chooser_branch_component_1 = require("../../shared/chooser-branch/chooser-branch.component");
var ClientPlanListModel_1 = require("src/app/core/Models/ListModels/ClientPlanListModel");
var ClientPlanClearModel_1 = require("src/app/core/Models/DtoModels/ClientPlanClearModel");
var manage_sales_plan_custom_component_1 = require("../components/manage-sales-plan-custom/manage-sales-plan-custom.component");
var ClientPlanModel_1 = require("src/app/core/Models/EntityModels/ClientPlanModel");
var manage_sales_plan_component_1 = require("../components/manage-sales-plan/manage-sales-plan.component");
var ClientPlanDuplicateModel_1 = require("src/app/core/Models/DtoModels/ClientPlanDuplicateModel");
var SalesPlanComponent = /** @class */ (function () {
    function SalesPlanComponent(_AppMessageService, confirmationService, messageService, _ClientPlanService, _translationLoaderService, _translateService, dialogService, _MenuService, _commonCrudService) {
        var _this = this;
        this._AppMessageService = _AppMessageService;
        this.confirmationService = confirmationService;
        this.messageService = messageService;
        this._ClientPlanService = _ClientPlanService;
        this._translationLoaderService = _translationLoaderService;
        this._translateService = _translateService;
        this.dialogService = dialogService;
        this._MenuService = _MenuService;
        this._commonCrudService = _commonCrudService;
        this.gridModel = {
            message: '',
            statusCode: 0,
            executionDate: undefined,
            succeeded: false,
            data: [],
            total: 0
        };
        this.searchModel = {
            clientId: 0,
            clientCode: '',
            branchId: 0,
            branchCode: '',
            clientTypeId: 0,
            fromDate: new Date(),
            toDate: new Date(),
            Take: 30,
            Skip: 0,
            Term: '',
            FilterBy: [],
            SortBy: undefined,
            TermBy: ""
        };
        this.advanced = false;
        this.isLoading = false;
        this.first = 0;
        this.clearModel = {
            clearDate: new Date()
        };
        this.MANAGE_PLAN_HEADER = '';
        this.GERNEY_STC_HEADER = '';
        this.CHOOSE_BRANCH = '';
        this.CHOOSE_CLIENT = '';
        this._translationLoaderService.loadTranslations(en_1.locale, ar_1.locale);
        this._translateService.get('Create Sales Plan').subscribe(function (res) { _this.MANAGE_PLAN_HEADER = res; });
        this._translateService.get('Sales Plan Statistics').subscribe(function (res) { _this.GERNEY_STC_HEADER = res; });
        this._translateService.get('Choose Branch').subscribe(function (res) { _this.CHOOSE_BRANCH = res; });
        this._translateService.get('Choose Client').subscribe(function (res) { _this.CHOOSE_CLIENT = res; });
    }
    SalesPlanComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.menuItems = [
            {
                label: 'Upload',
                icon: 'pi pi-fw pi-upload',
                command: function (event) { return _this.Manage('upload'); }
            },
            {
                label: 'Clear',
                icon: 'pi pi-fw pi-times',
                command: function (event) { return _this.Manage('clear'); }
            },
            {
                label: 'Template',
                icon: 'pi pi-fw pi-cloud-download',
                command: function (event) { return _this.Manage('template'); }
            },
        ];
    };
    SalesPlanComponent.prototype.filter = function (event) {
        return __awaiter(this, void 0, void 0, function () {
            var _this = this;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        console.log(event);
                        this.isLoading = true;
                        this.searchModel.Skip = event.first;
                        this.searchModel.Take = event.rows;
                        console.log(this.searchModel);
                        this.searchModel.SortBy = { Order: "", Property: "" };
                        if (event.sortField) {
                            this.searchModel.SortBy.Property = event.sortField;
                            if (event.sortOrder == 1) {
                                this.searchModel.SortBy.Order = "asc";
                            }
                            else {
                                this.searchModel.SortBy.Order = "desc";
                            }
                        }
                        return [4 /*yield*/, this._commonCrudService.post("ClientPlan/filter", this.searchModel, ClientPlanListModel_1.ClientPlanListModel).then(function (res) {
                                // await this._ClientPlanService.Filter(this.searchModel).then(res => {
                                _this.gridModel = res;
                                _this.isLoading = false;
                            })];
                    case 1:
                        _a.sent();
                        return [2 /*return*/];
                }
            });
        });
    };
    SalesPlanComponent.prototype.smartFilter = function (event) {
        return __awaiter(this, void 0, void 0, function () {
            var _this = this;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        if (!(event.keyCode == 13)) return [3 /*break*/, 2];
                        this.first = 0;
                        this.searchModel.Skip = 0;
                        this.isLoading = true;
                        return [4 /*yield*/, this._commonCrudService.post("ClientPlan/filter", this.searchModel, ClientPlanListModel_1.ClientPlanListModel).then(function (res) {
                                // await this._ClientPlanService.Filter(this.searchModel).then(res => {
                                _this.gridModel = res;
                                _this.isLoading = false;
                            })];
                    case 1:
                        _a.sent();
                        _a.label = 2;
                    case 2: return [2 /*return*/];
                }
            });
        });
    };
    SalesPlanComponent.prototype.reloadFilter = function () {
        return __awaiter(this, void 0, void 0, function () {
            var _this = this;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        this.selected = null;
                        this.isLoading = true;
                        return [4 /*yield*/, this._commonCrudService.post("ClientPlan/filter", this.searchModel, ClientPlanListModel_1.ClientPlanListModel).then(function (res) {
                                // await this._ClientPlanService.Filter(this.searchModel).then(res => {
                                _this.gridModel = res;
                                _this.isLoading = false;
                            })];
                    case 1:
                        _a.sent();
                        return [2 /*return*/];
                }
            });
        });
    };
    SalesPlanComponent.prototype.advancedFilter = function () {
        return __awaiter(this, void 0, void 0, function () {
            var _this = this;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        this.isLoading = true;
                        this.first = 0;
                        this.searchModel.Skip = 0;
                        return [4 /*yield*/, this._commonCrudService.post("ClientPlan/filter", this.searchModel, ClientPlanListModel_1.ClientPlanListModel).then(function (res) {
                                // await this._ClientPlanService.Filter(this.searchModel).then(res => {
                                _this.gridModel = res;
                                _this.isLoading = false;
                            })];
                    case 1:
                        _a.sent();
                        return [2 /*return*/];
                }
            });
        });
    };
    SalesPlanComponent.prototype.clearFilter = function () {
        return __awaiter(this, void 0, void 0, function () {
            return __generator(this, function (_a) {
                this.searchModel = {
                    clientId: 0,
                    clientCode: '',
                    branchId: 0,
                    branchCode: '',
                    clientTypeId: 0,
                    fromDate: new Date(),
                    toDate: new Date(),
                    Take: 30,
                    Skip: 0,
                    Term: '',
                    FilterBy: [],
                    SortBy: undefined,
                    TermBy: ""
                };
                return [2 /*return*/];
            });
        });
    };
    SalesPlanComponent.prototype.Manage = function (operation) {
        return __awaiter(this, void 0, void 0, function () {
            var ref, ref, ref;
            var _this = this;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        if (operation == 'upload') {
                            ref = this.dialogService.open(manage_sales_plan_component_1.ManageSalesPlanComponent, {
                                header: this.MANAGE_PLAN_HEADER,
                                width: '400px',
                                contentStyle: { "max-height": "600px", "height": "600px", "overflow": "auto" },
                                baseZIndex: 10000
                            });
                            ref.onClose.subscribe(function () {
                                _this.reloadFilter();
                            });
                        }
                        if (operation == 'add') {
                            ref = this.dialogService.open(manage_sales_plan_custom_component_1.ManageSalesPlanCustomComponent, {
                                header: this.MANAGE_PLAN_HEADER,
                                width: '400px',
                                contentStyle: { "max-height": "600px", "height": "600px", "overflow": "auto" },
                                baseZIndex: 10000
                            });
                            ref.onClose.subscribe(function () {
                                _this.reloadFilter();
                            });
                        }
                        if (operation == 'edit') {
                            if (this.selected && this.selected.planId > 0) {
                                ref = this.dialogService.open(manage_sales_plan_custom_component_1.ManageSalesPlanCustomComponent, {
                                    data: { planId: this.selected.planId },
                                    header: this.MANAGE_PLAN_HEADER,
                                    width: '400px',
                                    contentStyle: { "max-height": "600px", "height": "600px", "overflow": "auto" },
                                    baseZIndex: 10000
                                });
                                ref.onClose.subscribe(function () {
                                    _this.reloadFilter();
                                });
                            }
                        }
                        if (operation == 'delete') {
                            if (this.selected != null && this.selected.planId > 0) {
                                this.confirmationService.confirm({
                                    message: this._AppMessageService.MESSAGE_CONFIRM,
                                    accept: function () { return __awaiter(_this, void 0, void 0, function () {
                                        var model;
                                        var _this = this;
                                        return __generator(this, function (_a) {
                                            this.isLoading = true;
                                            model = {};
                                            model.planId = this.selected.planId;
                                            this._commonCrudService.post("ClientPlan/Delete", model, ClientPlanModel_1.ClientPlanModel).then(function (res) {
                                                // this._ClientPlanService.Delete(model).then(res => {
                                                _this.advancedFilter();
                                                _this.refreshMenu();
                                                _this.isLoading = false;
                                                if (res.succeeded == true) {
                                                    _this.messageService.add({ severity: 'success', detail: _this._AppMessageService.MESSAGE_OK });
                                                }
                                                else {
                                                    _this.messageService.add({ severity: 'error', detail: _this._AppMessageService.MESSAGE_ERROR });
                                                }
                                            });
                                            return [2 /*return*/];
                                        });
                                    }); },
                                    reject: function () {
                                        //reject action
                                    }
                                });
                            }
                        }
                        if (operation == 'duplicate') {
                            this.isLoading = true;
                            this._commonCrudService.post("ClientPlan/Duplicate", this.clearModel, ClientPlanDuplicateModel_1.ClientPlanDuplicateModel).then(function (res) {
                                // this._ClientPlanService.Duplicate(this.clearModel).then(res => {
                                _this.advancedFilter();
                                _this.isLoading = false;
                            });
                        }
                        if (operation == 'clear') {
                            this.isLoading = true;
                            this._commonCrudService.post("ClientPlan/Clear", this.clearModel, ClientPlanClearModel_1.ClientPlanClearModel).then(function (res) {
                                // this._ClientPlanService.Clear(this.clearModel).then(res => {
                                _this.advancedFilter();
                                _this.isLoading = false;
                            });
                        }
                        if (!(operation == 'template')) return [3 /*break*/, 2];
                        this.isLoading = true;
                        return [4 /*yield*/, this._CommonCrudService.getFile("ClientPlan/template")];
                    case 1:
                        (_a.sent()).subscribe(function (data) {
                            console.log(data);
                            var downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
                            var a = document.createElement('a');
                            a.setAttribute('style', 'display:none;');
                            document.body.appendChild(a);
                            a.download = "TargetTemplate_" + new Date().toISOString().split('.')[0].replace(/[^\d]/gi, '');
                            a.href = URL.createObjectURL(downloadedFile);
                            a.target = '_blank';
                            a.click();
                            document.body.removeChild(a);
                            _this.isLoading = false;
                        });
                        _a.label = 2;
                    case 2:
                        if (!(operation == 'download')) return [3 /*break*/, 4];
                        this.isLoading = true;
                        return [4 /*yield*/, this._ClientPlanService.Download(this.searchModel)];
                    case 3:
                        (_a.sent()).subscribe(function (data) {
                            console.log(data);
                            var downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
                            var a = document.createElement('a');
                            a.setAttribute('style', 'display:none;');
                            document.body.appendChild(a);
                            a.download = "CuurentTarget_" + new Date().toISOString().split('.')[0].replace(/[^\d]/gi, '');
                            a.href = URL.createObjectURL(downloadedFile);
                            a.target = '_blank';
                            a.click();
                            document.body.removeChild(a);
                            _this.isLoading = false;
                        });
                        _a.label = 4;
                    case 4:
                        this.refreshMenu();
                        return [2 /*return*/];
                }
            });
        });
    };
    SalesPlanComponent.prototype.onSelectionChange = function (event) {
        return __awaiter(this, void 0, void 0, function () {
            return __generator(this, function (_a) {
                this.refreshMenu();
                return [2 /*return*/];
            });
        });
    };
    SalesPlanComponent.prototype.refreshMenu = function () {
    };
    SalesPlanComponent.prototype.choose_Branch = function () {
        var _this = this;
        var ref = this.dialogService.open(chooser_branch_component_1.ChooserBranchComponent, {
            header: this.CHOOSE_BRANCH,
            width: '600px',
            modal: true,
            height: "90%"
        });
        ref.onClose.subscribe(function (branch) {
            if (branch) {
                _this.searchModel.branchId = branch.branchId;
                _this.searchModel.branchCode = branch.branchCode;
                _this.searchModel.clientId = 0;
                _this.searchModel.clientCode = '';
            }
        });
    };
    SalesPlanComponent.prototype.clear_Branch = function () {
        this.searchModel.branchId = 0;
        this.searchModel.branchCode = '';
        this.searchModel.clientId = 0;
        this.searchModel.clientCode = '';
    };
    SalesPlanComponent.prototype.choose_Client = function () {
        var _this = this;
        var ref = this.dialogService.open(chooser_client_component_1.ChooserClientComponent, {
            header: this.CHOOSE_CLIENT,
            width: '90%',
            modal: true,
            height: "90%"
        });
        ref.onClose.subscribe(function (client) {
            if (client) {
                _this.searchModel.clientId = client.clientId;
                _this.searchModel.clientCode = client.clientCode;
            }
        });
    };
    SalesPlanComponent.prototype.clear_Client = function () {
        this.searchModel.clientId = 0;
        this.searchModel.clientCode = '';
    };
    SalesPlanComponent = __decorate([
        core_1.Component({
            selector: 'app-sales-plan',
            templateUrl: './sales-plan.component.html',
            styleUrls: ['./sales-plan.component.scss']
        })
    ], SalesPlanComponent);
    return SalesPlanComponent;
}());
exports.SalesPlanComponent = SalesPlanComponent;
