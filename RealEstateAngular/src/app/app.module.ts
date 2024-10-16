import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ImageGridComponent } from './components/image-grid/image-grid.component';
import { MainContentComponent } from './components/main-content/main-content.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { SearchBarComponent } from './components/search-bar/search-bar.component';
import { SearchInputGroupComponent } from './components/search-input-group/search-input-group.component';
import { SelectComponent } from './components/select/select.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { DataGridComponent } from './components/data-grid/data-grid.component';
import { IconCardComponent } from './components/icon-card/icon-card.component';
import { NumberInputComponent } from './components/number-input/number-input.component';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    NavigationComponent,
    ImageGridComponent,
    MainContentComponent,
    SearchInputGroupComponent,
    SelectComponent,
    SearchBarComponent,
    DataGridComponent,
    IconCardComponent,
    NumberInputComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, FormsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
