function printInReverse(nums) {
    let numbers = Number(nums);
    for (let i =nums.length - 1; i >= 0; i--) {
        console.log(nums[i]);

    }
}
printInReverse(['1', '2', '3']);