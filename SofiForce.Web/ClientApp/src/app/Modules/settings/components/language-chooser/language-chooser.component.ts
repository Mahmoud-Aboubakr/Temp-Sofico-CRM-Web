import { Component, OnInit } from '@angular/core';
import { DynamicDialogRef } from 'primeng/dynamicdialog';

@Component({
  selector: 'app-language-chooser',
  templateUrl: './language-chooser.component.html',
  styleUrls: ['./language-chooser.component.scss']
})
export class LanguageChooserComponent implements OnInit {

  languages = [];
  selected = 'ar';

  constructor(private ref: DynamicDialogRef,) { }

  ngOnInit(): void {
    this.languages = [{ code: 'en', name: 'English' }, { code: 'ar', name: 'Arabic' }];
  }

  save() {
    console.log(this.selected);
    if (this.selected != null) {
      this.ref.close(this.selected)
    }
  }
}
