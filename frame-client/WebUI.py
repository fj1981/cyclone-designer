#!/usr/bin/python
# -*- coding: UTF-8 -*- 

import sys
import os
from os import path
import zipfile

p2 = os.getcwd()
print(p2)
cur_folder = path.join(p2,'FrameClient') 
p2=path.dirname(p2)

print(cur_folder)
p2=path.join(p2,'web-ui','build')
z = zipfile.ZipFile(path.join(cur_folder,'res.zip'), 'w', zipfile.ZIP_DEFLATED)
print('11111111111111111111')
print(p2)
for filepath,dirnames,filenames in os.walk(p2):
    for filename in filenames:
        file_full_path =path.join(filepath,filename)
        relative_path  = file_full_path.replace(p2,'');
        z.write(file_full_path,relative_path)
        print (file_full_path)
        print (relative_path)
z.close()
