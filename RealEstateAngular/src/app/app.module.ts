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
import { CardCarouselComponent } from './components/card-carousel/card-carousel.component';
import { ImageCardComponent } from './components/image-card/image-card.component';
import { FooterComponent } from './components/footer/footer.component';
import { NotFoundPageComponent } from './pages/not-found-page/not-found-page.component';
import { PropertyPageComponent } from './pages/property-page/property-page.component';
import { GalleryComponent } from './components/gallery/gallery.component';
import { TextCardComponent } from './components/text-card/text-card.component';
import { MapComponent } from './components/map/map.component';
import { TableComponent } from './components/table/table.component';
import { PropertyListPageComponent } from './pages/property-list-page/property-list-page.component';

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
    CardCarouselComponent,
    ImageCardComponent,
    FooterComponent,
    NotFoundPageComponent,
    PropertyPageComponent,
    GalleryComponent,
    TextCardComponent,
    MapComponent,
    TableComponent,
    PropertyListPageComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, FormsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
