import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormPageComponent } from './pages/form-page/form-page.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { NotFoundPageComponent } from './pages/not-found-page/not-found-page.component';
import { PropertyListPageComponent } from './pages/property-list-page/property-list-page.component';
import { PropertyPageComponent } from './pages/property-page/property-page.component';

const routes: Routes = [
  { path: 'home', component: HomePageComponent },
  { path: '', component: HomePageComponent },
  { path: 'property/:id', component: PropertyPageComponent },
  { path: 'list', component: PropertyListPageComponent },
  { path: 'post-property', component: FormPageComponent },
  { path: 'not-found', component: NotFoundPageComponent },
  { path: '**', pathMatch: 'full', component: NotFoundPageComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
