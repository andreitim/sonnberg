import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AuthGuard } from './guards/auth.guard';
import { MessagesComponent } from './messages/components/messages/messages.component';
import { PropertiesComponent } from './properties/components/properties/properties.component';
import { PropertyComponent } from './properties/components/property/property.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [ AuthGuard ],
    children: [
      { path: 'properties', component: PropertiesComponent },
      { path: 'properties/:id', component: PropertyComponent },
      { path: 'messages', component: MessagesComponent }    
    ]
  },
  { path: '**', component: HomeComponent, pathMatch: `full` }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
