// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  
  production: false,

  client_kind_request: 'diplom_client_kind',

// bogya
  hod_api_url: "https://localhost:*/",
  hod_sessionConst: {
    username: 'hod_username',
    role: 'hod_rolename',
    department: 'hod_department',
    accessTokenName: 'hod_accessToken',
    ownCookie: 'hodpart'
  },
  hod_auth: {
    // втисит
    email: 'teach1@ugtu.net',
    pass: 'qwer',
  },

// semka
  brs_api_url: "https://localhost:*/",
  brs_sessionConst: {
    username: '',
    role: '',
    department: '',
    accessTokenName: '',
    ownCookie: ''
  },
  brs_auth: {
    // someone
    email: '',
    pass: '',
  },
  

};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
