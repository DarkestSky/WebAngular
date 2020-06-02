import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {FetchDataComponent} from './pages/fetch-data/fetch-data.component';
import {HomeComponent} from './pages/home/home.component';
import {EditArticleComponent} from './pages/edit-article/edit-article.component';
import {ViewArticleComponent} from './pages/view-article/view-article.component';
import {SpaceComponent} from './pages/space/space.component';
import {FansComponent} from './pages/space/fans/fans.component';
import {FansFansComponent} from './pages/space/fans/fans-fans/fans-fans.component';
import {FansFollowsComponent} from './pages/space/fans/fans-follows/fans-follows.component';
import {FallbackComponent} from './pages/fallback/fallback.component';
import {PersonPageComponent} from './pages/space/person-page/person-page.component';
import {ExerciseComponent} from './pages/exercise/exercise.component';

const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: '/home'},
  {path: 'fetch-data', component: FetchDataComponent},
  {path: 'exercise', component: ExerciseComponent},
  {path: 'home', component: HomeComponent},
  {path: 'edit-article/:articleId', component: EditArticleComponent},
  {path: 'view-article/:articleId', component: ViewArticleComponent},
  {
    path: 'space/:userId', component: SpaceComponent, children: [
      {path: '', component: PersonPageComponent},
      {
        path: 'fans', component: FansComponent, children: [
          {path: 'fans', component: FansFansComponent},
          {path: 'follows', component: FansFollowsComponent}
        ]
      }
    ]
  },
  {path: '**', component: FallbackComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
