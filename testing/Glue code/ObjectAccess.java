package loginModule;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.Properties;

import org.openqa.selenium.By;

public class ObjectAccess {
	static Properties p= new Properties();
	static File f ;
	
	 public void openProperty(String m1) throws IOException {
		f = new File("C:/Project/Cinema Cafe/Cinema Cafe/src/com/pom/"+m1+".properties");
		 FileInputStream fin = new FileInputStream(f);
			p.load(fin);
	}
	
	public ObjectAccess() throws IOException {
		
	}
	
	static public By getlocator(String n){
		String n1=p.getProperty(n);
		String ns[]=n1.split(",");
		String loc=ns[0];
		String val=ns[1];
		
		if (loc.equals("id")) {
			return(By.id(val));
		}
		else if (loc.equals("name")) {
			return(By.name(val));
		}
		else if (loc.equals("cssSelector")) {
			return(By.cssSelector(val));
		}
		
		else if (loc.equals("xpath")) {
			return(By.xpath(val));
		}
		else {
			return null;
		}
		
		
		
	}

	public static void main(String[] args) throws IOException {
	ObjectAccess ob=new ObjectAccess();
	}

}

