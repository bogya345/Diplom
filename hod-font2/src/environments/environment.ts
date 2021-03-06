// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  
  production: false,

  client_kind_request: 'diplom_client_kind',

// bogya
  // hod_api_url: "https://localhost:44316/",
  hod_api_url: "https://localhost:5001/",

  hod_sessionConst: {
    username: 'hod_username',
    access_role_id: 'hod_roleid',
    access_role: 'hod_rolename',
    dep: 'hod_department',
    dep_id: 'hod_departmentid',
    accessTokenName: 'hod_accessToken',
    date: 'hod_dateExpired',
    ownCookie: 'hodpart'
  },
  
  hod_auth: {
    // втисит 
    // email: 't1@ugtu.net', 
    // pass: 'password1',
    email: 'dorogobeda@ugtu.net', 
    pass: 'password',
    // email: 'pelmegovr@ugtu.net', 
    // pass: 'password',
  }

};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
