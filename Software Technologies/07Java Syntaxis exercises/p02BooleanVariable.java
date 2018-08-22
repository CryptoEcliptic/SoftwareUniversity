import java.util.Scanner;

public class p02BooleanVariable {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String input = scan.next();

        switch (input) {
            case "True":
                System.out.println("Yes");
                break;
            case "False":
                System.out.println("No");
                break;
        }
    }
}
