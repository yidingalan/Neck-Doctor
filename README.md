<div style="text-align:center"><img src ="http://challengepost-s3-challengepost.netdna-ssl.com/photos/production/software_photos/000/356/643/datas/gallery.jpg" /></div>
<div style="text-align:center"><img src ="http://challengepost-s3-challengepost.netdna-ssl.com/photos/production/software_photos/000/357/662/datas/gallery.jpg" /></div>

<a href="http://devpost.com/software/neck-doctor">Devpost Link</a>
## Created by

<a href="https://github.com/DongJunJin">Dong Jun Jin</a></br>
<a href="https://github.com/Jkoza">Josh Koza</a></br>
<a href="https://github.com/peterl328">Yang Leng</a></br>
<a href="https://github.com/yidingalan">Alan Wang</a></br>

## Inspiration
My mother would always comes into my room and tell me: "Andrew, adjust your neck. You're going into the monitor". Normally I do not pay attention to my neck, but there were times when that would annoy me because she would ask me to adjust my neck every time. Afterwards, I realized this was becoming a trend amongst young kids and people who would always work in front of his monitors trying to do his job. Then the idea came to me. "Why don't I build something that could detect unhealthy sitting postures so people would be more aware of their position when they're at a computer?". I realized that many people were suffering from this due to the symptoms called "turtle neck" that if not payed attention to can lead to permanent spinal damage . If we are more aware of, we could have a more healthy lifestyle thus the number of treatment for necks can reduce significantly.

## What it does
The user will have a Microsoft Kinect mounted on the top of the monitor. 
The Kinect takes joint positions of the user and using machine learning we can classify whether the user has a healthy posture or not. If it is not in a healthy state for long duration, it will sends out a notification to the user's phone  and creates a graphical report in a windows application. We made sure not to send the notification to the user constantly as this would annoy them and might result in the user to not use this. From this application, the user can improve his posture and have a healthy lifestyle.

## How we built it
This application has two major components. One is the windows application that scans the user's joint and shows the report and the other is a python program that receives results from the machine learning servers and notifies the user's via text when appropriate.

## Challenges we ran into
Initially when we were coming up with the UI to output the data from the windows kinect we did not know which method was more efficient. We were deciding between Python or C# to do the UI since we lacked knowledge with C# but WPF used C# to create its application.

The machine learning part was extremely complex as we had to get the Wolfram Development Platform to work with the kinect data sets from the csv files. We had to reorganize the data sets in a manner such that the wolfram machine learning could crunch the data.

Since we had multiple variables all trying to work together, we needed a massive amount of data crunching in to create the presets to initialize the parameters. This was extremely complicated as we had to manipulate the data the kinect gave and analyse it to a point where the machine learning could train with that set and produce results.

One minor challenge we ran into was exchanging files between one another as we did not use git hub to share and merge different codes we had individually created.

- Toast Notification

## Accomplishments that we're proud of
When we got the windows application to output the graph and allow the user to begin using the kinect, we were proud because we had no basic knowledge and had to build from the ground up with C# and XAML.

After testing and retesting, we got the joint positions for the kinect to work at a optimal level such that the joint positions did not crumple. This was done through calibrating the distances required for the kinect to recognize the user.

When we finally got the machine learning from the Wolfram Development Platform to work and finally get a calibration to output the differences, it felt amazing as it was a challenge to try to make it work in the first place.

## What we learned
From this hack, I learned about C# and XAML which was totally new to me as I have never worked with the language itself.

## What's next for Neck Doctor
The neck doctor could be further improved by adding in different parameters (e.g. acceleration, velocity, stretching) to create a much more accurate and precise sequence for the machine learning to take in data and give accurate results. These results can be checked by the doctor if a system is implemented between hospitals then a accurate analysis can be done for both the patient and the hospital.
