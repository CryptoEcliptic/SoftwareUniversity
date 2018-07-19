function symmetric(nums) {
    let lines = Number(nums[0]);
    let result = '';
    for (let i = 1; i <= lines; i++) {
        if (isSymetric(i.toString()))
            result += i + " "
    }
        console.log(result);
    function isSymetric(currNumber) {
        for (let i = 0; i < currNumber.length / 2; i++) {
            if (currNumber[i] != currNumber[currNumber.length - i - 1])
                return false;
        }
        return true;
    }
}
