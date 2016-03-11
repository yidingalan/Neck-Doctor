import sys
import pycurl
import json
import requests
import pprint
from bs4 import BeautifulSoup
import urllib.request
import re

from twilio.rest import TwilioRestClient
ACCOUNT_SID = 'ACb72c0ffc7b0c256357ee90a27ec2965a'
AUTH_TOKEN = '9f7e4ec356995a3a2d05a02604044d22'
client = TwilioRestClient(ACCOUNT_SID, AUTH_TOKEN)


req = urllib.request.Request('https://www.wolframcloud.com/objects/user-a6c115d7-85ff-457a-89d2-1ebdd5a377db/data')
with urllib.request.urlopen(req) as response:
   the_page = response.read()

soup = BeautifulSoup(the_page, 'html.parser')
results = soup.find(attrs={"class" : "embedExpression"})
results = results.string

results = re.findall(r'[0-9]+', results)
print(results)
unhealthy = int(results[0])
healthy = int(results[1])

percentage = (unhealthy/(healthy+unhealthy)*100)
str_body = ""
# > 10% good
if percentage >= 10 and percentage < 20
    str_body = "Keep it up! Your posture is good!"
# > 20% n
    str_body = "Your sitting posture is okay. A slight improvement would be awesome"
# > 30% bad
    str_body = "You need to start paying attention to your posture."
# > 40% really bad
    str_body = "Stop what you are doing now. Stand up and stretch up."
client.messages.create(to='+14165712421',
                       from_='+12567403948',
                       body = str_body)
