import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { ImageGridComponent } from './components/image-grid/image-grid.component';
import { MainContentComponent } from './components/main-content/main-content.component';
import { SearchInputGroupComponent } from './components/search-input-group/search-input-group.component';

@NgModule({
  declarations: [AppComponent, HomePageComponent, NavigationComponent, ImageGridComponent, MainContentComponent, SearchInputGroupComponent],
  imports: [BrowserModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
