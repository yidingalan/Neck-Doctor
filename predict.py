import sys
import json
import requests
import pprint
from bs4 import BeautifulSoup
import urllib.request
import re

from twilio.rest import TwilioRestClient
ACCOUNT_SID = 'YOUR ACCOUNT ID'
AUTH_TOKEN = 'YOUR AUTH TOKEN'
client = TwilioRestClient(ACCOUNT_SID, AUTH_TOKEN)


req = urllib.request.Request('YOUR WOLFRAM DATA URL')
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
if percentage <= 10:
    str_body = "Keep it up! Your posture is good!"
# > 20% n
elif percentage <= 20 and percentage > 10:
    str_body = "Your sitting posture is okay. A slight improvement would be awesome"
# > 30% ba
elif percentage <= 30 and percentage > 20:
    str_body = "You need to start paying attention to your posture."
# > 40% really bad
elif percentage > 30:
    str_body = "Stop what you are doing now. Stand up and stretch up."

client.messages.create(to='SEND TO',
                       from_='FROM',
                       body = "str_body")
