import java.util.Scanner;

public class p14FitStringInTwentyCharacters {
    public static void main(String[] args) {

        Scanner scann = new Scanner(System.in);

        String input = scann.nextLine();

        if (input.length() >= 20)
        {
            System.out.println(input.substring(0, 20));
        }
        else {
            for (int i = 0; i < 20; i++) {
                if (i >= input.length()) {
                    System.out.print("*");
                    continue;
                }

                System.out.print(input.charAt(i));
            }
        }
    }
}