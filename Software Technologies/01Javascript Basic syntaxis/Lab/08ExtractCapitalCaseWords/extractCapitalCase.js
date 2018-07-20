function extractCaps(arr) {
    let words = arr.join(",");
    let splitted = words.split(/\W+/);
    let notEmpty = splitted.filter(word => word.length > 0);
    let uppercased = notEmpty.filter(isUpper);
    console.log(uppercased.join((", ")));

    function isUpper(str) {
       return str === str.toUpperCase();
    }
}
extractCaps(['PHP, Java and HTML']);