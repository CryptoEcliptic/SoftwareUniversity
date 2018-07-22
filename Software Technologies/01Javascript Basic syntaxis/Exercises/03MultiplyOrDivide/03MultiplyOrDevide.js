function multiplyOrDivide(nums){
   if(nums[0]> nums[1]){
       let division = (nums[0] / nums[1])
       return division;
   }
   else if(nums[0] <= nums[1]){
       let multiplication = (nums[0] * nums[1])
       return multiplication;
   }
}