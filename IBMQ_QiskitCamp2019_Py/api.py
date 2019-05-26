"""This component creates an API for communications with Twitter"""

from IBMQ_QiskitCamp2019_Py.VAR import get_alice_keys, get_bob_keys
from flask import Flask, Response, request
from threading import Thread
import tweepy

# ##### Replies #####
BOB_FIRST = "All right, let's check this out"
BOB_SECOND = "These are my axes: "
ALICE_SECOND = "Nice! These are mine: "

ALICE_CHECK = "Bob, tell me your {} first bits"
BOB_CHECK = "Ok, I've got: "

EVE = "Hey everybody, see what this two are texting. Subscribe for more."

# ##### OAuth #####
# This functions returns the Bearer Token, from Twitter's authentication endpoint, to be included in subsequent requests
alice_consumer_key, alice_consumer_secret, alice_access_token, alice_access_token_secret = get_alice_keys()
alice_auth = tweepy.OAuthHandler(alice_consumer_key, alice_consumer_secret)
alice_auth.set_access_token(alice_access_token, alice_access_token_secret)

bob_consumer_key, bob_consumer_secret, bob_access_token, bob_access_token_secret = get_bob_keys()
bob_auth = tweepy.OAuthHandler(bob_consumer_key, bob_consumer_secret)
bob_auth.set_access_token(bob_access_token, bob_access_token_secret)

# ##### API #####
api = Flask(__name__)
api.config["SECRET_KEY"] = "clave secreta"
api_tweepy_alice = tweepy.API(alice_auth)
api_tweepy_bob = tweepy.API(bob_auth)


# ##### Unity side #####
@api.route("/posttweet", methods=["POST"])
def unity_post_tweet():
    """This function is called by Unity for posting a tweet on Twitter"""
    req = request.get_json()
    text, user, responseid = req["name"], req["user"], req["responseid"]
    if not responseid:
        responseid = None
    resp = {"id": twitter_post_tweet(text, user, responseid)}
    return Response(resp, status=200, mimetype='application/json', headers={'content-type': 'application/json'})


@api.route("/servidores", methods=["GET"])
def unity_get_tweet():
    """This function is called by Unity for getting a tweet on Twitter"""
    req = request.get_json()
    user, id = req["user"], req["id"]
    resp = {"text": twitter_get_tweet(user, id)}
    return Response(resp, status=200, mimetype='application/json', headers={'content-type': 'application/json'})


# ##### Tweeter side #####
def twitter_post_tweet(text, user, responseid=None):
    """This function post a tweet on Twitter"""
    if user == "Alic3_qiskit":
        if not responseid:
            api_tweepy_alice.update_status(text)
        else:
            api_tweepy_alice.update_status(text, responseid)
    if user == "Bob_q1skit":
        if not responseid:
            api_tweepy_bob.update_status(text)
        else:
            api_tweepy_bob.update_status(text, responseid)


def twitter_get_tweet(user, id):
    """This function post a tweet on Twitter"""
    tweet = None
    if user == "Alic3_qiskit":
        tweet = api_tweepy_alice.get_status(id).json()["text"]
    if user == "Bob_q1skit":
        tweet = api_tweepy_bob.get_status(id).json()["text"]
    return tweet


# ##### Main #####
class ApiThread(Thread):
    def __init__(self, port):
        super().__init__()
        self.port = port

    def run(self):
        api.run(port=self.port)


def main():
    api_thread = ApiThread(9090)
    api_thread.start()


if __name__ == "__main__":
    main()
