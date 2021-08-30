# VAnimate
This Projects goal is to make it very easy to generate svg Animations in c#. It takes care of generating the files and provides a lot of useful functionality to create Animations from imported or generated Data.

## Workflow
First one starts by having some sort of cool idea since the process provides almost no immediate visual feedback. Then the code to generate or import the data is written. The provided utility functions should then make it easy to convert the data into an svg object which can be printed to stdout. To get the file simply compile run and redirect stdout into the target file.

## Status
This project is in it's infancy, my first goal is to implement the components of the svg standard that I consider to be essential then I will focus on animations of simple Elements till I have a good grip at which point I'm going to start working on Paths and other more complicated things.

## Contribute
If you have any suggestions or want to point out something please don't hesitate to do so. I don't have a lot of expierience with projects like this and welcome any help. If you wish to contribute something please **[contact me first](mailto:mail@stefanschmauch.eu?subject=VAnimate%20Contribution&body=Hello%20fellow%20Programmer "Send me an Email")** I would hate to reject your hard work because it would change the architecture or because it wouldn't fit in this project. If you created something cool and want others to see there is the Examples folder.

##Browser Support
All implemented svg features are supported in at least Safari, Chrome and Firefox including their mobile counterparts. No support for deprecated features.
