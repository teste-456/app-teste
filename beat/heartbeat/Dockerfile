FROM docker.elastic.co/beats/heartbeat:8.1.2

ENV setup.kibana.host=kibana:5601

ADD ./heartbeat.yml /usr/share/heartbeat/heartbeat.yml

USER root

RUN chown root:heartbeat /usr/share/heartbeat/heartbeat.yml

USER heartbeat
