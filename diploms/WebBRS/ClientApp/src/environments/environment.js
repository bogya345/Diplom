"use strict";
// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
Object.defineProperty(exports, "__esModule", { value: true });
exports.environment = void 0;
exports.environment = {
    debug: false,
    production: false,
    apiUrl: 'https://localhost:44336/',
    authUrl: 'https://localhost:44371/',
    tokenWhiteListedDomains: ['localhost:44371'],
    sessionConst: {
        username: 'hod_username',
        role: 'hod_rolename',
        roleId: 'hod_roleid',
        department: 'hod_department',
        accessTokenName: 'WebBRS_access_token'
    },
    // втисит
    email: 'teach1@ugtu.net',
    pass: 'qwer'
};
/*
 * In development mode, to ignore zone related error stack frames such as
 * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
 * import the following file, but please comment it out in production mode
 * because it will have performance impact when throw error
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
//# sourceMappingURL=environment.js.map