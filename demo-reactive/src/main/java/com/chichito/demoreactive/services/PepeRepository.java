package com.chichito.demoreactive.services;

import org.springframework.data.repository.reactive.ReactiveCrudRepository;
import org.springframework.stereotype.Repository;

import com.chichito.demoreactive.models.Pepe;

@Repository
public interface PepeRepository extends ReactiveCrudRepository<Pepe, Long> {}
