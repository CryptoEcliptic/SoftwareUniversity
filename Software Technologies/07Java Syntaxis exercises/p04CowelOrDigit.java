import java.util.Scanner;

public class p04CowelOrDigit {
    public static void main(String[] args) {
        String vowelsUpper = "AEIOUY";

        Scanner scanner = new Scanner(System.in);

        char input = scanner.next().charAt(0);

        if (vowelsUpper.indexOf(input) >= 0 || vowelsUpper.toLowerCase().indexOf(input) >= 0) {
            System.out.println("vowel");
        }
        else if (Character.isDigit(input)) {
            System.out.println("digit");
        }
        else {
            System.out.println("other");
        }
    }
}
