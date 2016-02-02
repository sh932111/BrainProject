<?php
class FolderUtils {
	//新增資料夾
	function createFolder($dir) {
		if(!mkdir($dir, 0777, true)) {
			print_r(error_get_last());
			return false;
		}
		else {
			return true;
		}
	}

	//移除資料夾
	function rmFolder($dir) {
		foreach(scandir($dir) as $file) {
			if ('.' === $file || '..' === $file) continue;
			if (is_dir("$dir/$file")) $this->rmFolder("$dir/$file");
			else unlink("$dir/$file");
		}
		rmdir($dir);
	}

	//複製資料夾
	function copyFolder($from_dir,$to_dir){  
        if(!is_dir($from_dir)){  
            return false ;  
        } 
        
        $from_files = scandir($from_dir);  

        if(!file_exists($to_dir)){  
            mkdir($to_dir); // @mkdir($to_dir) << 跟這樣差異在哪!?     
        }  
        if( ! empty($from_files)){  
            foreach ($from_files as $file){  
                if($file == '.' || $file == '..' ){  
                    continue;  
                }  
                  
                if(is_dir($from_dir.'/'.$file)){
                    copyFolder($from_dir.'/'.$file,$to_dir.'/'.$file);  
                }else{
                    copy($from_dir.'/'.$file,$to_dir.'/'.$file);  
                }  
            }  
        }
        return true ;
    }
    //$folder -> copyFolder("userPhoto/",$data_path."/userPhoto")
}
?>