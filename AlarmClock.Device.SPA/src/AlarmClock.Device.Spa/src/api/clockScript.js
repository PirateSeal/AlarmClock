/*
 * File: clockScript.js                                                        #
 * Project: alarmclock                                                         #
 * File Created: Tuesday,2nd June 2019 02:31:29 pm                             #
 * Author: Le Phoque Pirate                                                    #
 * --------------------                                                        #
 * Last Modified: Wednesday, 5th June 2019 12:17:49 pm                         #
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       #
 */

//DO NOT CHANGE !!!
// Set the offset on the y-Axis for each number of the clock
const size = 86;

let date;
let clock;
let classList = ["visible", "close", "far", "far", "distant", "distant"];

// Return actual time as HHMMSS pattern
function padClock(p, n) {
    return p + ("0" + n).slice(-2);
}

function getClock() {
    date = new Date();
    return [date.getHours(), date.getMinutes(), date.getSeconds()].reduce(
        padClock,
        ""
    );
}

function getClass(n, i2) {
    return (
        classList.find(function(class_, classIndex) {
            return Math.abs(n - i2) === classIndex;
        }) || ""
    );
}

export function runClock(columns) {
    setInterval(function() {
        clock = getClock();
        columns.forEach(function(ele, i) {
            let n = +clock[i];
            let offset = -n * size;

            ele.style.transform =
                "translateY(calc(50vh + " +
                offset +
                "px - " +
                size / 2 +
                "px))";

            Array.from(ele.children).forEach(function(ele2, i2) {
                ele2.className = "num " + getClass(n, i2);
            });
        });
    }, 200 + Math.E * 10);
}
