package com.login;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;

import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.firefox.FirefoxDriver;

import cucumber.api.PendingException;
import cucumber.api.java.en.Given;
import cucumber.api.java.en.Then;
import cucumber.api.java.en.When;

public class Registration extends ObjectAccess {
	


public Registration() throws IOException {
		super();
		// TODO Auto-generated constructor stub
	}

static WebDriver driver=new FirefoxDriver();

static File f=new File("C:/automation/selenium/Cinemacafe/Excel files/Registration.xlsx");
 static  FileInputStream f1;
	static XSSFWorkbook wb;
	static XSSFSheet sh;
	public String  read(int r,int c, String sht) throws IOException
	{
		
		  FileInputStream f1=new FileInputStream(f);
			XSSFWorkbook wb=new XSSFWorkbook(f1);
			XSSFSheet sh=wb.getSheet(sht);
			String u="",p="";
		          try
					{
						if(sh.getRow(r).getCell(c).getCellType()==0)
						{
							int m=(int) sh.getRow(r).getCell(c).getNumericCellValue();
							u=String.valueOf(m);
						}
						else
						{
							u=sh.getRow(r).getCell(c).getStringCellValue();
						}
					}
					catch(Exception e)
					{
						if(e.equals("NullPointerException"))
							u=null;
					}
			
			return u;
			
	}
	public void write(int r,int c,String s, String sht) throws IOException
	{
		 FileInputStream f1=new FileInputStream(f);
			XSSFWorkbook wb=new XSSFWorkbook(f1);
			XSSFSheet sh=wb.getSheet(sht);
			sh.getRow(r).createCell(c).setCellValue(s);
			FileOutputStream fo=new FileOutputStream(new File("C:/automation/selenium/Cinemacafe/Excel files/Registration.xlsx"));
			  wb.write(fo);
			  fo.close();
	}
	
	
	public void status(int r, int c, String sht) throws IOException {
		 if (read(r,c,sht).equals(read(r,(c+1),sht))) {
		    	write(r, (c+2), "Pass",sht);
			} else {
				write(r, (c+2), "Fail",sht);
			}
	}

@Given("^User is on Registration Page$")
public void User_is_on_Registration_Page()  {
    driver.get("172.16.170.67/cinemacafe1");
    driver.findElement(getlocator("cna")).click();
    
    
}

/*@Given("^CANCEL is displayed on the Registration page$")
public void CANCEL_is_displayed_on_the_Registration_page()  {
    // Express the Regexp above with the code you wish you had
    
}

@When("^User clicks on CANCEL link$")
public void User_clicks_on_CANCEL_link()  {
    // Express the Regexp above with the code you wish you had
   
}

@Then("^USER should redirect to the Cinema Cafe page$")
public void USER_should_redirect_to_the_Cinema_Cafe_page() {
    // Express the Regexp above with the code you wish you had
    


@When("^user is on Registration page$")
public void user_is_on_Registration_page()  {
	driver.get("172.16.170.67/cinemacafe1");
    driver.findElement(getlocator("cna")).click();

    
}

@Then("^the title should be Registration$")
public void the_title_should_be_Registration()  {
   
}*/

@When("^User enters valid User ID, valid Name, valid Mobile, valid Password, valid Answer and click on Register button$")
public void User_enters_valid_User_ID_valid_Name_valid_Mobile_valid_Password_valid_Answer_and_click_on_Register_button() throws IOException  {
    driver.findElement(getlocator("uid")).sendKeys(read(1, 0, "data"));
    driver.findElement(getlocator("name")).sendKeys(read(1, 1, "data"));
    driver.findElement(getlocator("mob")).sendKeys(read(1, 2, "data"));
    driver.findElement(getlocator("pass")).sendKeys(read(1, 3, "data"));
    driver.findElement(getlocator("ans")).sendKeys(read(1, 4, "data"));
    
}

@Then("^It should redirect to Cinema Cafe Page$")
public void It_should_redirect_to_Cinema_Cafe_Page() throws IOException  {
   write(1, 6, driver.getTitle(), "data");
   status(1, 5, "data");
}

@When("^User enters valid Name, valid Mobile, valid Password, valid Answer and click on Register button$")
public void User_enters_valid_Name_valid_Mobile_valid_Password_valid_Answer_and_click_on_Register_button() throws IOException {
	driver.findElement(getlocator("uid")).sendKeys(read(2, 0, "data"));
    driver.findElement(getlocator("name")).sendKeys(read(2, 1, "data"));
    driver.findElement(getlocator("mob")).sendKeys(read(2, 2, "data"));
    driver.findElement(getlocator("pass")).sendKeys(read(2, 3, "data"));
    driver.findElement(getlocator("ans")).sendKeys(read(2, 4, "data"));
}  

@Then("^User gets message - User Id is blank. Please provide a User Id$")
public void User_gets_message_User_Id_is_blank_Please_provide_a_User_Id() throws IOException  {
	//write(2, 6, driver.getTitle(), "data");
	   status(2, 5, "data");

}

@When("^User enters valid User ID, valid Mobile, valid Password, valid Answer and click  on Register button$")
public void User_enters_valid_User_ID_valid_Mobile_valid_Password_valid_Answer_and_click_on_Register_button() throws IOException  {
	driver.findElement(getlocator("uid")).sendKeys(read(3, 0, "data"));
    driver.findElement(getlocator("name")).sendKeys(read(3, 1, "data"));
    driver.findElement(getlocator("mob")).sendKeys(read(3, 2, "data"));
    driver.findElement(getlocator("pass")).sendKeys(read(3, 3, "data"));
    driver.findElement(getlocator("ans")).sendKeys(read(3, 4, "data"));
    
}

@Then("^User gets message - Name is blank. Please provide a Name.$")
public void User_gets_message_Name_is_blank_Please_provide_a_Name() throws IOException  {
	status(3, 5, "data");
    
}


@When("^User enters valid User ID,valid Name,valid Password,valid Answer and click on Register button$")
public void User_enters_valid_User_ID_valid_Name_valid_Password_valid_Answer_and_click_on_Register_button() throws IOException {
	driver.findElement(getlocator("uid")).sendKeys(read(4, 0, "data"));
    driver.findElement(getlocator("name")).sendKeys(read(4, 1, "data"));
    driver.findElement(getlocator("mob")).sendKeys(read(4, 2, "data"));
    driver.findElement(getlocator("pass")).sendKeys(read(4, 3, "data"));
    driver.findElement(getlocator("ans")).sendKeys(read(4, 4, "data"));
   
   
}

@Then("^It should redirect to Cinema Cafe Page too$")
public void It_should_redirect_to_Cinema_Cafe_Page_too() throws IOException {
	status(4, 5, "data");
    
}

@When("^User enters valid User ID, valid Name, valid Mobile, valid Answer and click  on Register button$")
public void User_enters_valid_User_ID_valid_Name_valid_Mobile_valid_Answer_and_click_on_Register_button() throws IOException {
	driver.findElement(getlocator("uid")).sendKeys(read(5, 0, "data"));
    driver.findElement(getlocator("name")).sendKeys(read(5, 1, "data"));
    driver.findElement(getlocator("mob")).sendKeys(read(5, 2, "data"));
    driver.findElement(getlocator("pass")).sendKeys(read(5, 3, "data"));
    driver.findElement(getlocator("ans")).sendKeys(read(5, 4, "data"));
}

@Then("^User gets message - Password is blank Please provide a Password.$")
public void User_gets_message_Password_is_blank_Please_provide_a_Password() throws IOException  {
	status(5, 5, "data");
}

@When("^User enters valid User ID, valid Name, valid Mobile, valid Password and click  on Register button$")
public void User_enters_valid_User_ID_valid_Name_valid_Mobile_valid_Password_and_click_on_Register_button() throws IOException  {
	driver.findElement(getlocator("uid")).sendKeys(read(6, 0, "data"));
    driver.findElement(getlocator("name")).sendKeys(read(6, 1, "data"));
    driver.findElement(getlocator("mob")).sendKeys(read(6, 2, "data"));
    driver.findElement(getlocator("pass")).sendKeys(read(6, 3, "data"));
    driver.findElement(getlocator("ans")).sendKeys(read(6, 4, "data"));
    
}

@Then("^User gets message - Answer is blank. Please provide an Answer.$")
public void User_gets_message_Answer_is_blank_Please_provide_an_Answer() throws IOException  {
	
    status(6, 5, "data");
}


@When("^user enters invalid User ID, valid Name, valid Mobile, valid Password, valid Answer and click  on Register button$")
public void user_enters_invalid_User_ID_valid_Name_valid_Mobile_valid_Password_valid_Answer_and_click_on_Register_button() throws IOException  {
	
	driver.findElement(getlocator("uid")).sendKeys(read(7, 0, "data"));
    driver.findElement(getlocator("name")).sendKeys(read(7, 1, "data"));
    driver.findElement(getlocator("mob")).sendKeys(read(7, 2, "data"));
    driver.findElement(getlocator("pass")).sendKeys(read(7, 3, "data"));
    driver.findElement(getlocator("ans")).sendKeys(read(7, 4, "data"));
     
}

@Then("^User gets message - User Id should be an email id \\(or\\) user Id already exists$")
public void User_gets_message_User_Id_should_be_an_email_id_or_user_Id_already_exists() throws IOException  {
    
	status(7, 5, "data");
}

@When("^User enters valid User ID, Name less than (\\d+) charecters, valid Mobile, valid Password, valid Answer and click  on Register button$")
public void User_enters_valid_User_ID_Name_less_than_charecters_valid_Mobile_valid_Password_valid_Answer_and_click_on_Register_button(int arg1) throws IOException  {
	
	driver.findElement(getlocator("uid")).sendKeys(read(8, 0, "data"));
    driver.findElement(getlocator("name")).sendKeys(read(8, 1, "data"));
    driver.findElement(getlocator("mob")).sendKeys(read(8, 2, "data"));
    driver.findElement(getlocator("pass")).sendKeys(read(8, 3, "data"));
    driver.findElement(getlocator("ans")).sendKeys(read(8, 4, "data"));
       
    
}

@Then("^User gets message - Name is less than (\\d+) characters$")
public void User_gets_message_Name_is_less_than_characters(int arg1) throws IOException  {
	status(8, 5, "data");
    
}

@When("^User enters valid User ID, Name greater than (\\d+) charecters, valid Mobile, valid Password, valid Answer and click  on Register button$")
public void User_enters_valid_User_ID_Name_greater_than_charecters_valid_Mobile_valid_Password_valid_Answer_and_click_on_Register_button(int arg1) throws IOException  {
	driver.findElement(getlocator("uid")).sendKeys(read(9, 0, "data"));
    driver.findElement(getlocator("name")).sendKeys(read(9, 1, "data"));
    driver.findElement(getlocator("mob")).sendKeys(read(9, 2, "data"));
    driver.findElement(getlocator("pass")).sendKeys(read(9, 3, "data"));
    driver.findElement(getlocator("ans")).sendKeys(read(9, 4, "data"));
    
}

@Then("^User gets message - Name is greater than (\\d+) characters$")
public void User_gets_message_Name_is_greater_than_characters(int arg1) throws IOException  {
	status(9, 5, "data");
    
}

@When("^User enters valid User ID, Name with numbers, valid Mobile, valid Password, valid Answer and click  on Register button$")
public void User_enters_valid_User_ID_Name_with_numbers_valid_Mobile_valid_Password_valid_Answer_and_click_on_Register_button() throws IOException  {
	driver.findElement(getlocator("uid")).sendKeys(read(10, 0, "data"));
    driver.findElement(getlocator("name")).sendKeys(read(10, 1, "data"));
    driver.findElement(getlocator("mob")).sendKeys(read(10, 2, "data"));
    driver.findElement(getlocator("pass")).sendKeys(read(10, 3, "data"));
    driver.findElement(getlocator("ans")).sendKeys(read(10, 4, "data"));
    
}

@Then("^User gets message - Name is invalid$")
public void User_gets_message_Name_is_invalid() throws IOException  {
	status(10, 5, "data");
    
}

@When("^User enters valid User ID, Name with special characters, valid Mobile, valid Password, valid Answer and click  on Register button$")
public void User_enters_valid_User_ID_Name_with_special_characters_valid_Mobile_valid_Password_valid_Answer_and_click_on_Register_button() throws IOException  {
	driver.findElement(getlocator("uid")).sendKeys(read(11, 0, "data"));
    driver.findElement(getlocator("name")).sendKeys(read(11, 1, "data"));
    driver.findElement(getlocator("mob")).sendKeys(read(11, 2, "data"));
    driver.findElement(getlocator("pass")).sendKeys(read(11, 3, "data"));
    driver.findElement(getlocator("ans")).sendKeys(read(11, 4, "data"));


}

@Then("^User gets message - Name is having special characters$")
public void User_gets_message_Name_is_having_special_characters() throws IOException  {
	 status(11, 5, "data");

}

@When("^User enters valid User ID, valid Name, Mobile less than (\\d+) numbers, valid Password, valid Answer and click  on Register button$")
public void User_enters_valid_User_ID_valid_Name_Mobile_less_than_numbers_valid_Password_valid_Answer_and_click_on_Register_button(int arg1) throws IOException  {
	driver.findElement(getlocator("uid")).sendKeys(read(12, 0, "data"));
    driver.findElement(getlocator("name")).sendKeys(read(12, 1, "data"));
    driver.findElement(getlocator("mob")).sendKeys(read(12, 2, "data"));
    driver.findElement(getlocator("pass")).sendKeys(read(12, 3, "data"));
    driver.findElement(getlocator("ans")).sendKeys(read(12, 4, "data"));
}

@Then("^User gets message - Mobile number is less than (\\d+) numbers$")
public void User_gets_message_Mobile_number_is_less_than_numbers(int arg1) throws IOException {
	status(12, 5, "data");
    
   
}

@When("^User enters valid User ID, valid Name, Mobile greater than (\\d+) numbers, valid Password, valid Answer and click  on Register button$")
public void User_enters_valid_User_ID_valid_Name_Mobile_greater_than_numbers_valid_Password_valid_Answer_and_click_on_Register_button(int arg1) throws IOException  {
	
	driver.findElement(getlocator("uid")).sendKeys(read(13, 0, "data"));
    driver.findElement(getlocator("name")).sendKeys(read(13, 1, "data"));
    driver.findElement(getlocator("mob")).sendKeys(read(13, 2, "data"));
    driver.findElement(getlocator("pass")).sendKeys(read(13, 3, "data"));
    driver.findElement(getlocator("ans")).sendKeys(read(13, 4, "data"));
    
}

@Then("^User gets message - Mobile number is greater than (\\d+) numbers$")
public void User_gets_message_Mobile_number_is_greater_than_numbers(int arg1) throws IOException  {
	status(13, 5, "data");
}

@When("^User enters valid User Id,valid Name,Mobile having (\\d+) numbers,valid Password,valid Answer and click on Register button$")
public void User_enters_valid_User_Id_valid_Name_Mobile_having_numbers_valid_Password_valid_Answer_and_click_on_Register_button(int arg1) throws IOException  {
    // Express the Regexp above with the code you wish you had
	driver.findElement(getlocator("uid")).sendKeys(read(14, 0, "data"));
    driver.findElement(getlocator("name")).sendKeys(read(14, 1, "data"));
    driver.findElement(getlocator("mob")).sendKeys(read(14, 2, "data"));
    driver.findElement(getlocator("pass")).sendKeys(read(14, 3, "data"));
    driver.findElement(getlocator("ans")).sendKeys(read(14, 4, "data"));
    
}

@Then("^User gets message-Mobile is having (\\d+) numbers$")
public void User_gets_message_Mobile_is_having_numbers(int arg1) throws IOException  {
    // Express the Regexp above with the code you wish you had
	status(14, 5, "data"); 
}



@When("^User enters valid User ID, valid Name, having alphabet, valid Password, valid Answer and click  on Register button$")
public void User_enters_valid_User_ID_valid_Name_having_alphabet_valid_Password_valid_Answer_and_click_on_Register_button() throws IOException  {
	driver.findElement(getlocator("uid")).sendKeys(read(15, 0, "data"));
    driver.findElement(getlocator("name")).sendKeys(read(15, 1, "data"));
    driver.findElement(getlocator("mob")).sendKeys(read(15, 2, "data"));
    driver.findElement(getlocator("pass")).sendKeys(read(15, 3, "data"));
    driver.findElement(getlocator("ans")).sendKeys(read(15, 4, "data"));
}

@Then("^User gets message - Mobile number is invalid$")
public void User_gets_message_Mobile_number_is_invalid() throws IOException  {
	status(15, 5, "data");
	   
	 
}

@When("^User enters valid User ID, valid Name, Mobile which includes special characters, valid Password, valid Answer and click on Register button$")
public void User_enters_valid_User_ID_valid_Name_Mobile_which_includes_special_characters_valid_Password_valid_Answer_and_click_on_Register_button() throws IOException  {
	driver.findElement(getlocator("uid")).sendKeys(read(16, 0, "data"));
    driver.findElement(getlocator("name")).sendKeys(read(16, 1, "data"));
    driver.findElement(getlocator("mob")).sendKeys(read(16, 2, "data"));
    driver.findElement(getlocator("pass")).sendKeys(read(16, 3, "data"));
    driver.findElement(getlocator("ans")).sendKeys(read(16, 4, "data"));
}

@Then("^User gets message - Mobile number is having specail characters$")
public void User_gets_message_Mobile_number_is_having_specail_characters() throws IOException  {
	status(16, 5, "data");
}

@When("^User enters valid User ID, valid Name, valid Mobile, Password less than (\\d+) charecters, valid Answer and click  on Register button$")
public void User_enters_valid_User_ID_valid_Name_valid_Mobile_Password_less_than_charecters_valid_Answer_and_click_on_Register_button(int arg1) throws IOException  {
	
	driver.findElement(getlocator("uid")).sendKeys(read(17, 0, "data"));
    driver.findElement(getlocator("name")).sendKeys(read(17, 1, "data"));
    driver.findElement(getlocator("mob")).sendKeys(read(17, 2, "data"));
    driver.findElement(getlocator("pass")).sendKeys(read(17, 3, "data"));
    driver.findElement(getlocator("ans")).sendKeys(read(17, 4, "data"));
    
}

@Then("^User gets message - Password is less than (\\d+) characters$")
public void User_gets_message_Password_is_less_than_characters(int arg1) throws IOException  {
	status(17, 5, "data");
	
}

@When("^User enters valid User ID, valid Name, valid Mobile, Password greater than (\\d+) characters, valid Answer and click  on Register button$")
public void User_enters_valid_User_ID_valid_Name_valid_Mobile_Password_greater_than_characters_valid_Answer_and_click_on_Register_button(int arg1) throws IOException  {
	driver.findElement(getlocator("uid")).sendKeys(read(18, 0, "data"));
    driver.findElement(getlocator("name")).sendKeys(read(18, 1, "data"));
    driver.findElement(getlocator("mob")).sendKeys(read(18, 2, "data"));
    driver.findElement(getlocator("pass")).sendKeys(read(18, 3, "data"));
    driver.findElement(getlocator("ans")).sendKeys(read(18, 4, "data"));
}

@Then("^User gets message - Password is greater than (\\d+) characters$")
public void User_gets_message_Password_is_greater_than_characters(int arg1) throws IOException  {
	
	status(18, 5, "data");
}

@When("^User enters valid User ID, valid Name, valid Mobile, Password with special characters, valid Answer and click  on  Register button$")
public void User_enters_valid_User_ID_valid_Name_valid_Mobile_Password_with_special_characters_valid_Answer_and_click_on_Register_button() throws IOException  {
	driver.findElement(getlocator("uid")).sendKeys(read(19, 0, "data"));
    driver.findElement(getlocator("name")).sendKeys(read(19, 1, "data"));
    driver.findElement(getlocator("mob")).sendKeys(read(19, 2, "data"));
    driver.findElement(getlocator("pass")).sendKeys(read(19, 3, "data"));
    driver.findElement(getlocator("ans")).sendKeys(read(19, 4, "data"));
    
	
}

@Then("^User gets message - Password is having special characters$")
public void User_gets_message_Password_is_having_special_characters() throws IOException  {
    
	 status(19, 5, "data");
}

@When("^User enters valid User ID, valid Name, valid Mobile, valid Password, Answer less than (\\d+) charecters and click  on Register button$")
public void User_enters_valid_User_ID_valid_Name_valid_Mobile_valid_Password_Answer_less_than_charecters_and_click_on_Register_button(int arg1) throws IOException  {
	driver.findElement(getlocator("uid")).sendKeys(read(20, 0, "data"));
    driver.findElement(getlocator("name")).sendKeys(read(20, 1, "data"));
    driver.findElement(getlocator("mob")).sendKeys(read(20, 2, "data"));
    driver.findElement(getlocator("pass")).sendKeys(read(20, 3, "data"));
    driver.findElement(getlocator("ans")).sendKeys(read(20, 4, "data"));
    
}

@Then("^User gets message - Answer is less than (\\d+) characters$")
public void User_gets_message_Answer_is_less_than_characters(int arg1) throws IOException {
	
	status(20, 5, "data");
}

@When("^User enters valid User ID, valid Name, valid Mobile, valid Password, Answer greater than (\\d+) charecters and click  on Register button$")
public void User_enters_valid_User_ID_valid_Name_valid_Mobile_valid_Password_Answer_greater_than_charecters_and_click_on_Register_button(int arg1) throws IOException  {
	driver.findElement(getlocator("uid")).sendKeys(read(21, 0, "data"));
    driver.findElement(getlocator("name")).sendKeys(read(21, 1, "data"));
    driver.findElement(getlocator("mob")).sendKeys(read(21, 2, "data"));
    driver.findElement(getlocator("pass")).sendKeys(read(21, 3, "data"));
    driver.findElement(getlocator("ans")).sendKeys(read(21, 4, "data"));
	
}

@Then("^User gets message - Answer is greater than (\\d+) characters$")
public void User_gets_message_Answer_is_greater_than_characters(int arg1) throws IOException  {
	status(21, 5, "data");
	
}

@When("^User enters valid User ID, valid Name, valid Mobile, valid Password, Answer having special character and click  on Register button$")
public void User_enters_valid_User_ID_valid_Name_valid_Mobile_valid_Password_Answer_having_special_character_and_click_on_Register_button() throws IOException  {
	
	driver.findElement(getlocator("uid")).sendKeys(read(22, 0, "data"));
    driver.findElement(getlocator("name")).sendKeys(read(22, 1, "data"));
    driver.findElement(getlocator("mob")).sendKeys(read(22, 2, "data"));
    driver.findElement(getlocator("pass")).sendKeys(read(22, 3, "data"));
    driver.findElement(getlocator("ans")).sendKeys(read(22, 4, "data"));
	
   
}

@Then("^User gets message - Answer is invalid Please enter a valid Answer$")
public void User_gets_message_Answer_is_invalid_Please_enter_a_valid_Answer() throws IOException  {
    
    status(22, 5, "data");
}








}
