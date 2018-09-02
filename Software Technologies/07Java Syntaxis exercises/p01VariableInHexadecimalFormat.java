import java.util.Scanner;

public class pr01VariableInHexadecimalFormat {

    public static void main(String[] args){
//psvm+enter
        Scanner scan = new Scanner(System.in);
        String toConvert = scan.nextLine();

        int converted = Integer.parseInt(toConvert, 16);
        System.out.println(converted);
    }


}
