# Goal

Develop online magazine where users could participate according to their granted access privileges,
with this website the user who grant a Moderator privileges can write and manage articles. Besides, 
every login user can comment, like and bookmark articles, also s/he has his/her own profile where the written and/or bookmarked articles are listed there.



# Target audience

- Readers who are interested in online magazines.

# User Experience

## User Stories

1. As a website owner I want to:
   - Create a database.
   - Manage access priviliges.
2. As a Moderator I want to:
   - Write, update and delete my own articles.
   - Comment, like and bookmark articles.
3. As a user I can:
   - comment on articles. 
   - Like articles.
   - Search for an article.
   - Filter articles according to topics.
   - Bookmark articles.
4. As a guest I can
   - Read articles.
   - Search for an article.

## Design

- The UX is easy to understand and use
- The content of each page is centered in the middle.

## Colors
Spicy mustard is the background color for all cards, that includes ( register/login, article, comment) card and the header/footer background as well , the shadow is grey. And the rest of the page remais white.

## Typography
Basicly, Lato is the font used and Sans-serif is the back-up font if Lato fails to load.

# System analysis
- Use case diagram

![Use case diagram](https://res.cloudinary.com/nazek/image/upload/v1690833977/readme/usecase-diagram.png)

# Database Design
- ERD diagram

![ERD](https://res.cloudinary.com/nazek/image/upload/v1690833977/readme/erd-diagram.png)

# Agile workflow

With the use of GitHub's kanban board, issues have been listed with labels for each, prioritising them in a manner that meets the project objective.

1. Adding essential features first
   - Backend functionalities have been added as a first iteration (install required libraries, create database with related tables, CRUD functionalities).
   - As a next step, templates and views that relate to CRUD have been done as a second iteration.
   - authentication with allauth take a place as a third step after testing the CRUD.
2. GitHub Features / Issues
   - The user stories have been given a Github issue, each is prioritized and is a given one of three labels (Must have , Should have, Could have).
     ![Issues](https://res.cloudinary.com/nazek/image/upload/v1690833977/readme/issues.png).

# Implementation Plan
The implementation plan have been written for each [user story](#user-stories) individually, 
available at the [backlog](https://github.com/users/Nazek-Altayeb/projects/3).
By clicking on each user story, details of how the feature is implemented will be displayed.

# Existing Features

## Register

Users who would like to create accounts in our site should use the register form first,
after registeration they will be directed to the login page.
there they will enjoy reading articles summaries.
In the other hand, there are three Moderators who manage the articles,
(names and password listed here [readme](README.md))
![Register](https://res.cloudinary.com/nazek/image/upload/v1690834782/readme/Register.png)

## Login

Below is the login form, the logged in user could be  a Moderator who grant full privileges, means s/he could create and manage articles.
otherwise s/he could participate (write comment, like, save articles)
![Login](https://res.cloudinary.com/nazek/image/upload/v1690834782/readme/login.png)

## Read more

Each article has the 'more' link, user could click on it in order to read the rest of the article and participate (write comment, like, save articles).
Also, the moderator can manage his/her own articles using this link.
![Read more](https://res.cloudinary.com/nazek/image/upload/v1690834783/readme/read-more.png)

## Add article

Users with Moderator privileges can add new articles using the below form.
![Add article](https://res.cloudinary.com/nazek/image/upload/v1690834783/readme/add-article.png)

## Update/Delete article

Users with Moderator privileges can update or delete their own articles.
![Update/Delete article](https://res.cloudinary.com/nazek/image/upload/v1690834783/readme/update-delete.png)

## Comment/Like/Bookmark

Logged in users can interact by leaving a comment or like/save a specific article.
![Comment/Like/Bookmark](https://res.cloudinary.com/nazek/image/upload/v1690834783/readme/comment-like-bookmark.png)

## Add topic

User with a Moderator privileges can add a new topic using the related form, later on they may create new articles under this new added topic.
![Add topic](https://res.cloudinary.com/nazek/image/upload/v1690834783/readme/add-topic.png)

## Search articles

All users including visitors can search for articles by to the author name or the article title/topic.
![Search articles](https://res.cloudinary.com/nazek/image/upload/v1690834783/readme/search.png)

# Testing

## Test Guide
Manual test is applied at all user stories,  available at the following [acceptance criteria guide](TEST.md).

# Fixed Bugs

- Bug: search feature fail to retrieve articles according to author name.
  - fix: add 'username' in query.
- Bug : Empty page displayed when no articles found
  - fix: add condition in search template to display 'no articles found' if no articles exist.
- Bug : layout of the home page break in mobile devices
  - fix : add media queries for smaller screen width.
- Bug :  push failed in heruko
  - fix: update the  backports.zoneinfo in requirement.txt.
- Bug: comment is not saved
  - Fix: add condition to check if comment form is valid.
- Bug: Get wrong number of likes
  - Fix : move the likes accumulator statement outside the if clause in get_context_data method.
- Bugs: errors accours because of typo in views methods and some templates.
  - Fix: correct variables/fields names.
- Bugs: Get errors and warnings when validating templates.
  - fix: remove duplicated Ids used in multiple elements, remove un-used tags.

# Un-fixed Bug
- Bug: p element shown when editing the article for update, 
  although the attribute 'safe' is used in order to prevent this.

# Validation

## Validation Guide

All written files have been validated, besides the website accessability and performance are validates as well,
validation  results available at the following [Validation guide](VALIDATION.md) 

# Technologies

## Environments and Hosting

- [Lucid](https://lucid.app/) (ERD diagrams)
- [GitHub](https://github.com/) (Version control)
- [Codeanywhere](https://codeanywhere.com) (IDE)
- [Heroku](https://heroku.com/) (Site hosting)
- [Cloudinary](https://cloudinary.com/) (Serving static media files)

## Libraries

- [Gunicorn](https://docs.djangoproject.com/en/4.1/howto/deployment/wsgi/gunicorn/) (Python HTTP server for WSGI applications)
- [pyscopg2](https://pypi.org/project/psycopg2/) (PostgreSQL Database adapter)
- [django-allauth](https://django-allauth.readthedocs.io/en/latest/) (User authentication)
- [django-crispy-forms](https://django-crispy-forms.readthedocs.io/en/latest/) (Control rendering behaviour of Django forms)

### Database

- [ElephantSQL](https://www.elephantsql.com/) (PostgreSQL database hosting)

# Deployment

#### Install libraries

Below are the libraries needed for deployment on Heroku.  For full explanation on how to install these libraries, refer to the links provided in [Technologies](#technologies).

- Install **Gunicorn** (server used to run Django on Heroku): ``pip3 install django gunicorn``
- Install **pyscopg2** (connects to PostgreSQL): ``pip 3 install dj_database_url pyscopg2``
- Install **Cloudinary** (host static files and images): ``pip3 install dj3-cloudinary-storage``

#### Create the Heroku App

- Log into Heroku and go to the Dashboard
- Click **New** and select **Create new app** from the drop-down
- Name app appropriately and choose relevant region, then click **Create App**

#### Create PostgreSQL database using ElephantSQL

This is necessary to create a database that can be accessed by Heroku. as it's not possible to access the database provided by Django by the deployed Heroku app.

- Log into ElephantSQL and go to Dashboard
- Click **Create New Instance**
- Set up a plan by providing a Name (project name) and select a Plan (for this project the free plan "Tiny Turtle" was chosen). Tags are optional.
- Click **Select Region** and choose appropriate Data center
- Click **Review**, check all details and click **Create Instance**
- Return to Dashboard on click on the name of the newly created instance
- Copy the database URL from the details section

#### Hide sensitive data

- Create ``env.py`` file and ensure it is included in the ``.gitignore`` file
- Add ``import os`` to env.py file and set environment variable **DATABASE_URL** to the URL copied from ElephantSQL (``os.environ["DATABASE_URL"]="<copiedURL>"``)
- Below, set **SECRET_KEY** variable (``os.environ["SECRET_KEY"]="mysecretkey"``, but be more inventive about the key string!)

#### Update Settings

- Add the following code at the top of ``settings.py`` to connect Django project to env.py:

    ````
      import os
      import dj_database_url
      if os.path.isfile('env.py'):
          import env
    ````

- Remove insecure secret key provide by Django in settings.py and refer to variable in env.py instead (``SECRET_KEY = os.environ.get('SECRET_KEY')``)

- To connect to new database, replace provided **DATABASE** variable with

    ````
    DATABASES = {
        'default': dj_database_url.parse(os.environ.get("DATABASE_URL"))
    }
    ````

- Save and migrate all changes made

#### Connect Heroku to Database

- In Heroku dashboard, go to **Settings** tab
- Add three new config vars **DATABASE_URL** (value is database URL), **SECRET_KEY** (value is secret key string) and **PORT** (value "8000")

#### Connect to Cloudinary

- In Cloudinary dashboard, copy **API Environment variable**
- In ``env.py`` file, add new variable ``os.environ["CLOUDINARY_URL"] = "<copied_variable"`` and remove ``CLOUDINARY_URL=`` from the variable string
- Add same variable value as new Heroku config var named **CLOUDINARY_URL**
- In ``settings.py``, in ``INSTALLED_APPS`` list, above ``django.contrib.staticfiles`` add ``cloudinary_storage``, below add ``cloudinary``
- To define Cloudinary as static file storage add the following to settings.py

    ````
    STATICFILES_STORAGE = 'cloudinary_storage.storage.StaticHashedCloudinaryStorage'

    DEFAULT_FILE_STORAGE = 'cloudinary_storage.storage.MediaCloudinaryStorage'
    ````

#### Set hosts

- In ``settings.py`` add

    ````
    ALLOWED_HOSTS = ['app-name.herokuapp.com', 'localhost']
    ````

# Development

### Fork

Any changes made to a forked repository do not affect the original repository.

- Log into GitHub and click on repository to download ([kush-magazine](https://github.com/Nazek-Altayeb/kush_magazine))
- Click the **Fork** buttonin the top right-hand corner
- Select a different owner if necessary
- Click **Create Fork**
- The repo is now in your chosen account and can be cloned or changed

### Clone

Changes made to a cloned repository will affect the original one.

- Navigate to the main page of the repostitory (this could be a forked instance)
- Click on the **Code** dropdown menu above the list of files
- Choose a method to copy the URL for the repository: either via **HTTPS**, by using an **SSH key**, or by using **GitHub CLI**
- In your work environment, open Git Bash and change current directory to target location for cloned repository
- Type ``git clone`` followed by the copied URL and press enter **Enter**

### Download as ZIP

- Log into GitHub and click on repository to download ([kush-magazine](https://github.com/Nazek-Altayeb/kush_magazine))
- Select **Code** and click "Download Zip" file
- Once download is completed, extract ZIP file and use in your local environment.
# Credits
- Code : below are resouces, that help to set up the environment and structure the code.
  - [Codemy.com channel](https://www.youtube.com/@Codemycom/playlists)
  - [Code Institute LMS | I Think Therefore I Blog](https://learn.codeinstitute.net/ci_program/diplomainfullstacksoftwarecommoncurriculum).
- Content : the below websites are references for the  written articles listed in my website.
  - [Wasim Ahmad articles](https://fstoppers.com/profile/74735/articles) Photograph articles.
  - [Yuni Wen articles](https://www.sciencedirect.com/science/article/pii/S0160791X23000714) Artificial intelligence articles.
  - [John P.A. Ioannidis articles](https://scholar.google.com/citations?user=JiiMY_wAAAAJ&hl=en) Epidemiology articles.
- Readme : The below README was a reference guide i have used to demonstrate and structure my project. 
  - [woohoo-haiku](https://github.com/Kathrin-ddggxh/woohoo-haiku) 

# Aknowledgement

- I programmed the project my self. references are added to the code for external source code.
- Many thanks to Mentor **Antonio Rodriguez** for continuous helpful feedback.
- Thanks to Tutors support at Code Institute for their support.
