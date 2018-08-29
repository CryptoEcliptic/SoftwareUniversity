import java.util.Arrays;
import java.util.Scanner;

public class p08MexSequenceOfIncreasingElements {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int[] nums = Arrays
                .stream(scan.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();
        int currentLength = 1;
        int maxLength = 1;
        int maxStart = 0;
        int currentStart = 0;

        for (int i = 1; i < nums.length; i++) {

            if(nums[i]>nums[i-1])
            {
                currentLength++;

                if(currentLength > maxLength)
                {
                    maxLength = currentLength;
                    maxStart = currentStart;
                }
            }
            else
            {
                currentLength = 1;
                currentStart = i;
            }
        }
        for (int i = maxStart; i < maxStart + maxLength; i++)
        {
            System.out.printf("%d ",nums[i]);
        }

    }
}
