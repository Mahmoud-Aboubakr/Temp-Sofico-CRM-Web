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
exports.ManagePromotionCriteriaAttrComponent = void 0;
var core_1 = require("@angular/core");
var en_1 = require("./i18n/en");
var ar_1 = require("./i18n/ar");
var PromotionCriteriaAttrCustomModel_1 = require("src/app/core/Models/EntityModels/PromotionCriteriaAttrCustomModel");
var PromotionCriteriaAttrModel_1 = require("src/app/core/Models/EntityModels/PromotionCriteriaAttrModel");
var chooser_product_all_component_1 = require("src/app/Modules/shared/chooser-product-all/chooser-product-all.component");
var PromotionCriteriaAttrCustomListModel_1 = require("src/app/core/Models/ListModels/PromotionCriteriaAttrCustomListModel");
var ManagePromotionCriteriaAttrComponent = /** @class */ (function () {
    function ManagePromotionCriteriaAttrComponent(_AppMessageService, confirmationService, messageService, _translationLoaderService, _translateService, ref, dialogService, config, _UtilService, _commonCrudService, _PromotionCriteriaAttrService, _PromotionCriteriaAttrCustomService) {
        var _this = this;
        this._AppMessageService = _AppMessageService;
        this.confirmationService = confirmationService;
        this.messageService = messageService;
        this._translationLoaderService = _translationLoaderService;
        this._translateService = _translateService;
        this.ref = ref;
        this.dialogService = dialogService;
        this.config = config;
        this._UtilService = _UtilService;
        this._commonCrudService = _commonCrudService;
        this._PromotionCriteriaAttrService = _PromotionCriteriaAttrService;
        this._PromotionCriteriaAttrCustomService = _PromotionCriteriaAttrCustomService;
        this.model = {
            attributeCode: '',
            attributeId: 0,
            attributeNameAr: '',
            attributeNameDesc: '',
            attributeNameEn: '',
            displayOrder: 0,
            canDelete: false,
            canEdit: false,
            isActive: true,
            isCustom: true
        };
        this.PromotionCriteriaAttrCustomModel = {
            attributeId: 0,
            customId: 0,
            valueFrom: '',
            isActive: true
        };
        this.PromotionCriteriaAttrCustomList = [];
        this.isLoading = false;
        this.isItemLoading = false;
        this.isUploadDone = false;
        this.showItems = false;
        this.showUpload = false;
        this.editMode = "";
        this.CHOOSE = '';
        this._translationLoaderService.loadTranslations(en_1.locale, ar_1.locale);
        this._translateService.get('Choose').subscribe(function (res) { _this.CHOOSE = res; });
        if (this.config.data) {
            if (+this.config.data.attributeId > 0) {
                this.model.attributeId = +this.config.data.attributeId;
            }
            if (this.config.data.editMode) {
                this.editMode = this.config.data.editMode;
            }
        }
    }
    ManagePromotionCriteriaAttrComponent.prototype.ngOnInit = function () {
        var _this = this;
        if (this.model.attributeId > 0) {
            this.isLoading = true;
            //get by id
            this._commonCrudService.get("PromotionCriteriaAttr/GetById?Id=" + this.model.attributeId, PromotionCriteriaAttrModel_1.PromotionCriteriaAttrModel).then(function (res) {
                if (res.succeeded == true) {
                    if (res.data) {
                        _this.model = res.data;
                    }
                    _this.isLoading = false;
                }
            });
            this._commonCrudService.get("PromotionCriteriaAttrCustom/getByAttribute?Id=" + this.model.attributeId, PromotionCriteriaAttrCustomListModel_1.PromotionCriteriaAttrCustomListModel).then(function (res) {
                if (res.succeeded == true) {
                    _this.PromotionCriteriaAttrCustomList = res.data;
                }
            });
        }
    };
    ManagePromotionCriteriaAttrComponent.prototype.Save = function () {
        return __awaiter(this, void 0, void 0, function () {
            var valid;
            var _this = this;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        valid = true;
                        if (this.model.attributeCode.trim().length == 0) {
                            valid = false;
                        }
                        if (valid == false) {
                            this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_INVALID });
                            return [2 /*return*/];
                        }
                        this.isLoading = true;
                        return [4 /*yield*/, this._commonCrudService.post("PromotionCriteriaAttr/Save", this.model, PromotionCriteriaAttrModel_1.PromotionCriteriaAttrModel).then(function (res) {
                                if (res.succeeded == true && res.data && res.data.attributeId > 0) {
                                    _this.model = res.data;
                                }
                                else {
                                    _this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: _this._AppMessageService.MESSAGE_ERROR });
                                }
                            })];
                    case 1:
                        _a.sent();
                        this.isLoading = false;
                        return [2 /*return*/];
                }
            });
        });
    };
    ManagePromotionCriteriaAttrComponent.prototype.saveItem = function () {
        return __awaiter(this, void 0, void 0, function () {
            var valid;
            var _this = this;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        valid = true;
                        this.PromotionCriteriaAttrCustomModel.attributeId = this.model.attributeId;
                        if (this.PromotionCriteriaAttrCustomModel.attributeId == 0) {
                            valid = false;
                        }
                        if (this.PromotionCriteriaAttrCustomModel.valueFrom.trim().length == 0) {
                            valid = false;
                        }
                        if (valid == false) {
                            this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_INVALID });
                            return [2 /*return*/];
                        }
                        this.isItemLoading = true;
                        return [4 /*yield*/, this._commonCrudService.post("PromotionCriteriaAttrCustom/Save", this.PromotionCriteriaAttrCustomModel, PromotionCriteriaAttrCustomModel_1.PromotionCriteriaAttrCustomModel).then(function (res) { return __awaiter(_this, void 0, void 0, function () {
                                var _this = this;
                                return __generator(this, function (_a) {
                                    switch (_a.label) {
                                        case 0:
                                            if (!(res.succeeded == true)) return [3 /*break*/, 2];
                                            //rebind grid
                                            return [4 /*yield*/, this._commonCrudService.get("PromotionCriteriaAttrCustom/getByAttribute?Id=" + this.model.attributeId, PromotionCriteriaAttrCustomListModel_1.PromotionCriteriaAttrCustomListModel).then(function (res) {
                                                    if (res.succeeded == true) {
                                                        _this.PromotionCriteriaAttrCustomList = res.data;
                                                    }
                                                })
                                                //reset
                                            ];
                                        case 1:
                                            //rebind grid
                                            _a.sent();
                                            //reset
                                            this.resetAttributeModel();
                                            this.messageService.add({ severity: 'success', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_OK });
                                            return [3 /*break*/, 3];
                                        case 2:
                                            this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_ERROR });
                                            _a.label = 3;
                                        case 3:
                                            this.isItemLoading = false;
                                            return [2 /*return*/];
                                    }
                                });
                            }); })];
                    case 1:
                        _a.sent();
                        return [2 /*return*/];
                }
            });
        });
    };
    ManagePromotionCriteriaAttrComponent.prototype.addLine = function () {
        this.resetAttributeModel();
        this.showItems = true;
    };
    ManagePromotionCriteriaAttrComponent.prototype.uploadExcelPopup = function () {
        this.showUpload = true;
    };
    ManagePromotionCriteriaAttrComponent.prototype.deleteLine = function () {
        var _this = this;
        this.isItemLoading = true;
        this._PromotionCriteriaAttrCustomService.Delete(this.PromotionCriteriaAttrCustomModel).then(function (res) { return __awaiter(_this, void 0, void 0, function () {
            var _this = this;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        if (!(res.succeeded == true)) return [3 /*break*/, 2];
                        //rebind grid
                        return [4 /*yield*/, this._commonCrudService.get("PromotionCriteriaAttrCustom/getByAttribute?Id=" + this.model.attributeId, PromotionCriteriaAttrCustomListModel_1.PromotionCriteriaAttrCustomListModel).then(function (res) {
                                if (res.succeeded == true) {
                                    _this.PromotionCriteriaAttrCustomList = res.data;
                                }
                            })
                            //reset
                        ];
                    case 1:
                        //rebind grid
                        _a.sent();
                        //reset
                        this.resetAttributeModel();
                        this.messageService.add({ severity: 'success', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_OK });
                        return [3 /*break*/, 3];
                    case 2:
                        this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_ERROR });
                        _a.label = 3;
                    case 3:
                        this.isItemLoading = false;
                        return [2 /*return*/];
                }
            });
        }); });
    };
    ManagePromotionCriteriaAttrComponent.prototype.resetAttributeModel = function () {
        this.PromotionCriteriaAttrCustomModel = {
            attributeId: 0,
            customId: 0,
            valueFrom: '',
            isActive: true
        };
    };
    ManagePromotionCriteriaAttrComponent.prototype.deleteAll = function () {
        var _this = this;
        if (this.model.attributeId != null && this.model.attributeId > 0) {
            this.confirmationService.confirm({
                message: this._AppMessageService.MESSAGE_CONFIRM,
                accept: function () { return __awaiter(_this, void 0, void 0, function () {
                    var model;
                    var _this = this;
                    return __generator(this, function (_a) {
                        this.isLoading = true;
                        model = {};
                        model.attributeId = this.model.attributeId;
                        this._PromotionCriteriaAttrCustomService.DeleteAllItem(model).then(function (res) { return __awaiter(_this, void 0, void 0, function () {
                            var _this = this;
                            return __generator(this, function (_a) {
                                switch (_a.label) {
                                    case 0:
                                        if (!(res.succeeded == true)) return [3 /*break*/, 2];
                                        this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });
                                        //rebind grid
                                        return [4 /*yield*/, this._commonCrudService.get("PromotionCriteriaAttrCustom/getByAttribute?Id=" + this.model.attributeId, PromotionCriteriaAttrCustomListModel_1.PromotionCriteriaAttrCustomListModel).then(function (res) {
                                                if (res.succeeded == true) {
                                                    _this.PromotionCriteriaAttrCustomList = res.data;
                                                }
                                            })];
                                    case 1:
                                        //rebind grid
                                        _a.sent();
                                        return [3 /*break*/, 3];
                                    case 2:
                                        this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });
                                        _a.label = 3;
                                    case 3:
                                        this.isLoading = false;
                                        return [2 /*return*/];
                                }
                            });
                        }); });
                        return [2 /*return*/];
                    });
                }); },
                reject: function () {
                    //reject action
                }
            });
        }
    };
    ManagePromotionCriteriaAttrComponent.prototype.downloadExcel = function () {
        return __awaiter(this, void 0, void 0, function () {
            var model;
            var _this = this;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        this.isLoading = true;
                        model = {};
                        model.attributeId = this.model.attributeId;
                        return [4 /*yield*/, (this._PromotionCriteriaAttrCustomService.Download(model)).subscribe(function (data) {
                                console.log(data);
                                var downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
                                var a = document.createElement('a');
                                a.setAttribute('style', 'display:none;');
                                document.body.appendChild(a);
                                a.download = "ItemAttribute_" + new Date().toISOString().split('.')[0].replace(/[^\d]/gi, '');
                                a.href = URL.createObjectURL(downloadedFile);
                                a.target = '_blank';
                                a.click();
                                document.body.removeChild(a);
                                _this.isLoading = false;
                            })];
                    case 1:
                        _a.sent();
                        return [2 /*return*/];
                }
            });
        });
    };
    ManagePromotionCriteriaAttrComponent.prototype.reload = function () {
        return __awaiter(this, void 0, void 0, function () {
            var _this = this;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        this.isLoading = true;
                        this.resetAttributeModel();
                        return [4 /*yield*/, this._commonCrudService.get("PromotionCriteriaAttrCustom/getByAttribute?Id=" + this.model.attributeId, PromotionCriteriaAttrCustomListModel_1.PromotionCriteriaAttrCustomListModel).then(function (res) {
                                if (res.succeeded == true) {
                                    _this.PromotionCriteriaAttrCustomList = res.data;
                                }
                                _this.isLoading = false;
                            })];
                    case 1:
                        _a.sent();
                        return [2 /*return*/];
                }
            });
        });
    };
    ManagePromotionCriteriaAttrComponent.prototype.choose_item = function () {
        var _this = this;
        var ref = this.dialogService.open(chooser_product_all_component_1.ChooserProductAllComponent, {
            header: this.CHOOSE,
            width: '80%',
            contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
            baseZIndex: 10000
        });
        ref.onClose.subscribe(function (product) {
            if (product) {
                _this.PromotionCriteriaAttrCustomModel.valueFrom = product.itemCode;
            }
        });
    };
    ManagePromotionCriteriaAttrComponent.prototype.myUploader = function (event, form) {
        var _this = this;
        this.isLoading = true;
        this.isUploadDone = false;
        event.files.forEach(function (file) {
            _this._PromotionCriteriaAttrCustomService.Upload(file, _this.model.attributeId).then(function (res) { return __awaiter(_this, void 0, void 0, function () {
                var _this = this;
                return __generator(this, function (_a) {
                    switch (_a.label) {
                        case 0:
                            if (!(res.succeeded == true)) return [3 /*break*/, 2];
                            this.showUpload = false;
                            return [4 /*yield*/, this._commonCrudService.get("PromotionCriteriaAttrCustom/getByAttribute?Id=" + this.model.attributeId, PromotionCriteriaAttrCustomListModel_1.PromotionCriteriaAttrCustomListModel).then(function (res) {
                                    if (res.succeeded == true) {
                                        _this.PromotionCriteriaAttrCustomList = res.data;
                                    }
                                })];
                        case 1:
                            _a.sent();
                            return [3 /*break*/, 3];
                        case 2:
                            this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: res.message });
                            _a.label = 3;
                        case 3:
                            this.isLoading = false;
                            return [2 /*return*/];
                    }
                });
            }); });
        });
        form.clear();
    };
    ManagePromotionCriteriaAttrComponent = __decorate([
        core_1.Component({
            selector: 'app-manage-promotion-criteria-attr',
            templateUrl: './manage-promotion-criteria-attr.component.html',
            styleUrls: ['./manage-promotion-criteria-attr.component.scss']
        })
    ], ManagePromotionCriteriaAttrComponent);
    return ManagePromotionCriteriaAttrComponent;
}());
exports.ManagePromotionCriteriaAttrComponent = ManagePromotionCriteriaAttrComponent;
