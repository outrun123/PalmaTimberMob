﻿Apache konfigurēt Directory vai VirtualHost ieliek: 

<IfModule mod_headers.c>
      Header set Access-Control-Allow-Origin "*"
      Header set Access-Control-Allow-Methods "GET, POST, PUT, DELETE, OPTIONS"
      Header set Access-Control-Allow-Headers "X-Requested-With, Content-Type, X-Token-Auth, Authorization"
</IfModule>
