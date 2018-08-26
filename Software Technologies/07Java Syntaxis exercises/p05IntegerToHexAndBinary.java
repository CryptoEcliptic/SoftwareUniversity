import java.util.Scanner;

public class p05IntegerToHexAndBinary {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int toConvert = scan.nextInt();

        System.out.println(Integer.toHexString(toConvert).toUpperCase());
        System.out.println(Integer.toBinaryString(toConvert));

    }
}
