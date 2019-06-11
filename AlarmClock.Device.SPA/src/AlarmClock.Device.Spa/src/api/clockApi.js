/*
 * File: clockApi.js                                                           *
 * Project: alarmclock                                                         *
 * File Created: Wednesday,3rd June 2019 11:27:24 am                           *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Thursday, 6th June 2019 9:40:41 am                           *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

import { getAsync } from "../helpers/apiHelper";

const endpoint = process.env.VUE_APP_BACKEND + "/api";

export async function getPresetList() {
    return await getAsync(`${endpoint}/preset`);
}

export async function getClockName() {
    return await getAsync(`${endpoint}/clock`);
}
