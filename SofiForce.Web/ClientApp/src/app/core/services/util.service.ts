import { Injectable } from "@angular/core";
import { Subject } from "rxjs";


@Injectable({
    providedIn: 'root'
  })
export class UtilService {
    public LocalDate = (dateTime) => {
        return new Date(new Date(dateTime).getFullYear(), new Date(dateTime).getMonth(), new Date(dateTime).getDate(), new Date(dateTime).getHours(), new Date(dateTime).getMinutes(), new Date(dateTime).getSeconds());

    }

    public FirstOFMonth = (dateTime) => {
        return new Date(new Date(dateTime).getFullYear(), new Date(dateTime).getMonth(), 1, new Date(dateTime).getHours(), new Date(dateTime).getMinutes(), new Date(dateTime).getSeconds());
    }
    public LastOFMonth = (dateTime) => {
        return new Date(new Date(dateTime).getFullYear(), new Date(dateTime).getMonth()+1, 0,23, 59, 59);
    }

    public Now = (dateTime) => {
        return new Date(new Date(dateTime).getFullYear(), new Date(dateTime).getMonth(), new Date(dateTime).getDate(), new Date(dateTime).getHours(), new Date(dateTime).getMinutes(), new Date(dateTime).getSeconds());

    }

    public StartDay = (dateTime) => {
        return new Date(new Date(dateTime).getFullYear(), new Date(dateTime).getMonth(), new Date(dateTime).getDate(), 0, 0, 1);

    }

    public EndDay = (dateTime) => {
        return new Date(new Date(dateTime).getFullYear(), new Date(dateTime).getMonth(), new Date(dateTime).getDate(), 23, 59, 59);

    }
    Counter=new Subject<number>();
}