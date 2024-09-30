import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CardCarouselComponent } from './components/card-carousel/card-carousel.component';
import { FooterComponent } from './components/footer/footer.component';
import { FormComponent } from './components/form/form.component';
import { GalleryComponent } from './components/gallery/gallery.component';
import { IconCardComponent } from './components/icon-card/icon-card.component';
import { ImageCardComponent } from './components/image-card/image-card.component';
import { ImageGridComponent } from './components/image-grid/image-grid.component';
import { MainContentComponent } from './components/main-content/main-content.component';
import { MapComponent } from './components/map/map.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { NumberInputComponent } from './components/number-input/number-input.component';
import { RadioComponent } from './components/radio/radio.component';
import { SearchBarComponent } from './components/search-bar/search-bar.component';
import { SearchInputGroupComponent } from './components/search-input-group/search-input-group.component';
import { SelectComponent } from './components/select/select.component';
import { TableComponent } from './components/table/table.component';
import { TextCardComponent } from './components/text-card/text-card.component';
import { TextareaComponent } from './components/textarea/textarea.component';
import { FormPageComponent } from './pages/form-page/form-page.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { NotFoundPageComponent } from './pages/not-found-page/not-found-page.component';
import { PropertyListPageComponent } from './pages/property-list-page/property-list-page.component';
import { PropertyPageComponent } from './pages/property-page/property-page.component';
import { MapSearchPageComponent } from './pages/map-search-page/map-search-page.component';

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
    FormPageComponent,
    FormComponent,
    RadioComponent,
    TextareaComponent,
    MapSearchPageComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, FormsModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
