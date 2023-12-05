import { LookupModel } from "./lookupModel";

export interface DateTypeModel extends LookupModel {
    isCustom: boolean;
    from: Date;
    to: Date;
}

