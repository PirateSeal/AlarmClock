var size = 86;
var columns = Array.from(document.getElementsByClassName("column"));
var d, c;
var classList = ["visible", "close", "far", "far", "distant", "distant"];
var use24HourClock = true;

function padClock(p, n) {
    return p + ("0" + n).slice(-2);
}

function getClock() {
    d = new Date();
    return [
        use24HourClock ? d.getHours() : d.getHours() % 12 || 12,
        d.getMinutes(),
        d.getSeconds()
    ].reduce(padClock, "");
}

function getClass(n, i2) {
    return (
        classList.find(function(class_, classIndex) {
            return Math.abs(n - i2) === classIndex;
        }) || ""
    );
}
