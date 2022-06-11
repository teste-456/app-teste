FROM docker.elastic.co/elasticsearch/elasticsearch:8.1.2

#ADD ./elasticsearch.yml /usr/share/elasticsearch/elasticsearch.yml

USER root

RUN sysctl -w vm.max_map_count=262144

#RUN chown root:elastic /usr/share/elasticsearch/elasticsearch.yml

#USER elastic
